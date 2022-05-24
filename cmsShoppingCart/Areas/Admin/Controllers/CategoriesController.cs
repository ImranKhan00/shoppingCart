using cmsShoppingCart.Infrastructure;
using cmsShoppingCart.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Linq;
using System.Threading.Tasks;

namespace cmsShoppingCart.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoriesController : Controller
	{
		private readonly shoppingCartDbContext context;
		public CategoriesController(shoppingCartDbContext context)
		{
			this.context = context;
		}
		//GET admin/categories
		public async Task<IActionResult> Index()
		{
			return View(await context.Categories.OrderBy(x=>x.Sorting).ToListAsync());
		}

		//GET admin/categories/create
		public IActionResult Create() => View();

		//POST admin/categories/create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(Category category)
		{
			if (ModelState.IsValid)
			{
				category.Slug = category.Name.ToLower().Replace(" ", "-");
				category.Sorting = 100;

				var slug = context.Categories.FirstOrDefault(x => x.Slug == category.Slug);
				if (slug != null)
				{
					ModelState.AddModelError("", "The category is already exists.");
					return View(category);
				}
				context.Add(category);
				await context.SaveChangesAsync();

				TempData["Success"] = "The category has been added!";

				return RedirectToAction("Index");
			}
			return View(category);
		}


		//GET admin/category/edit/5
		public async Task<ActionResult> Edit(int id)
		{
			Category category = await context.Categories.FindAsync(id);
			if (category == null)
			{
				return NotFound();
			}
			return View(category);
		}

		//POST admin/category/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(int id, Category category)
		{
			if (ModelState.IsValid)
			{
				category.Slug = category.Id == 1 ? "home" : category.Name.ToLower().Replace(" ", "-");

				var slug = context.Categories.Where(x => x.Id != id).FirstOrDefault(x => x.Slug == category.Slug);
				if (slug != null)
				{
					ModelState.AddModelError("", "The category is already exists.");
					return View(category);
				}
				context.Update(category);
				await context.SaveChangesAsync();

				TempData["Success"] = "The category has been Edited!";

				return RedirectToAction("Edit", new { id });
			}
			return View(category);
		}

		//GET admin/category/delete/5
		public async Task<ActionResult> Delete(int id)
		{
			Category category = await context.Categories.FindAsync(id);
			if (category == null)
			{
				TempData["Error"] = "The page does not exist!";
			}
			else
			{
				context.Categories.Remove(category);
				await context.SaveChangesAsync();

				TempData["Success"] = "The category has been deleted!";
			}
			return RedirectToAction("Index");
		}
		public async Task<ActionResult> Details(int id)
		{
			Category category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
			if (category == null)
			{
				return NotFound();
			}
			return View(category);
		}

		//POST admin/categories/reorder
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Reorder(int[] id)
		{
			int count = 1;

			foreach (var pageId in id)
			{
				Category category = await context.Categories.FindAsync(pageId);
				category.Sorting = count;
				context.Update(category);
				await context.SaveChangesAsync();
				count++;
			}
			return Ok();
		}

	}
}
