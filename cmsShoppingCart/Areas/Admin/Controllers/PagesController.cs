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
		 

		//GET admin/pages/edit/5
		public async Task<ActionResult> Edit(int id)
		{
			Page page = await context.Pages.FindAsync(id);
			if (page == null)
			{
				return NotFound();
			}
			return View(page);
		}

		//POST admin/pages/Edit
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(Page page)
		{
			if (ModelState.IsValid)
			{
				page.Slug = page.Id == 1 ? "home" : page.Title.ToLower().Replace(" ", "-");
				
				var slug = context.Pages.Where(x=>x.Id != page.Id).FirstOrDefault(x => x.Slug == page.Slug);
				if (slug != null)
				{
					ModelState.AddModelError("", "The page is already exists.");
					return View(page);
				}
				context.Update(page);
				await context.SaveChangesAsync();

				TempData["Success"] = "The page has been Edited!";

				return RedirectToAction("Edit",new { id = page.Id});
			}
			return View(page);
		}

		//GET admin/pages/delete/5
		public async Task<ActionResult> Delete(int id)
		{
			Page page = await context.Pages.FindAsync(id);
			if (page == null)
			{
				TempData["Error"] = "The page does not exist!";
			}
			else
			{
				context.Pages.Remove(page);
				await context.SaveChangesAsync();

				TempData["Success"] = "The page has been deleted!";
			}
			return RedirectToAction("Index");
		}

		//POST admin/pages/reorder
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Reorder(int[] id)
		{
			int count = 1;
			
			foreach(var pageId in id)
			{
				Page page = await context.Pages.FindAsync(pageId);
				page.Sorting = count;
				context.Update(page);
				await context.SaveChangesAsync();
				count++;
			}
			return Ok();
		}
	}
}
