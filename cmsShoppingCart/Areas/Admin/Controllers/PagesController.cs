using cmsShoppingCart.Infrastructure;
using cmsShoppingCart.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsShoppingCart.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class PagesController : Controller
	{
		private readonly shoppingCartDbContext context;
		public PagesController(shoppingCartDbContext context)
		{
			this.context = context;
		}

		//GET admin/pages
		public async Task<ActionResult> Index()
		{
			IQueryable<Page> pages = from p in context.Pages
															 orderby p.Sorting
															 select p;

			List<Page> pageList = await pages.ToListAsync();
			return View(pageList);
		}
		//GET admin/pages/details/5
		public async Task<ActionResult> Details(int id)
		{
			Page page = await context.Pages.FirstOrDefaultAsync(x => x.Id == id);
			if (page == null)
			{
				return NotFound();
			}
			return View(page);
		}

		//GET admin/pages/create
		public IActionResult Create() => View();


		//POST admin/pages/create
		[HttpPost]
		public async Task<ActionResult> Create(Page page)
		{
			if(ModelState.IsValid)
			{
				page.Slug = page.Title.ToLower().Replace(" ", "-");
				page.Sorting = 100;

				var slug = context.Pages.FirstOrDefault(x => x.Slug == page.Slug);
				if(slug != null)
				{
					ModelState.AddModelError("", "The title is already exists.");
					return View(page);
				}
				context.Add(page);
				await context.SaveChangesAsync();

				return RedirectToAction("Index");
			}
			return View(page);
		}
	}
}
