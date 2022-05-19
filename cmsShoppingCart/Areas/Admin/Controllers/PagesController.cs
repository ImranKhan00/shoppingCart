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
		public PagesController(shoppingCartDbContext	context)
		{
			this.context = context;
		}


		public async Task<ActionResult> Index()
		{
			IQueryable<Page> pages = from p in context.Pages 
															 orderby p.Sorting 
															 select p;

			List<Page> pageList = await pages.ToListAsync();
			return View(pageList);
		}

	}
}
