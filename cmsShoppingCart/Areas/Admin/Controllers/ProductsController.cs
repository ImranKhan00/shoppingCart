using cmsShoppingCart.Infrastructure;
using cmsShoppingCart.Models;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace cmsShoppingCart.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductsController : Controller
	{
		private readonly shoppingCartDbContext context;
		private readonly IWebHostEnvironment webHostEnvironment;
		public ProductsController(shoppingCartDbContext context)
		{
			this.context = context;
			this.webHostEnvironment = webHostEnvironment;
		}

		//GET admin/products
		public async Task<IActionResult> Index(int p=1)
		{
			int pageSize = 5;
			var products = context.Products.OrderByDescending(x => x.Id)
																		.Include(x => x.Category)
																		.Skip((p-1)*pageSize)
																		.Take(pageSize);

			ViewBag.PageNumber = p;
			ViewBag.PageRange = pageSize;
			ViewBag.TotalPages = (int)Math.Ceiling((decimal)context.Products.Count() / pageSize);

			return View(await products.ToListAsync());
		}

		//GET admin/products/create
		public IActionResult Create()
		{
			ViewBag.CategoryId = new SelectList(context.Categories.OrderBy(x => x.Sorting), "Id", "Name");

			return View();
		}


		//POST admin/products/create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(Product product)
		{
			if (ModelState.IsValid)
			{
				product.Slug = product.Name.ToLower().Replace(" ", "-");

				var slug = context.Products.FirstOrDefault(x => x.Slug == product.Slug);
				if (slug != null)
				{
					ModelState.AddModelError("", "The product is already exists.");
					return View(product);
				}


				string imageName = "noimage.png";
				if(product.ImageUpload != null)
				{
					string uploadsDir = Path.Combine(webHostEnvironment.WebRootPath, "media/products");
					imageName = Guid.NewGuid().ToString() + "_" + product.ImageUpload.FileName;
					string filePath = Path.Combine(uploadsDir, imageName);
					FileStream fs = new FileStream(filePath,FileMode.Create);
					await product.ImageUpload.CopyToAsync(fs);
					fs.Close();
				}
				product.Image = imageName;
				context.Add(product);
				await context.SaveChangesAsync();

				TempData["Success"] = "The product has been added!";

				return RedirectToAction("Index");
			}
			return View(product);
		}
	}
}
