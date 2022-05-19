using cmsShoppingCart.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Linq;

namespace cmsShoppingCart.Models
{
	public class SeedData
	{
		public static void Initialize(IServiceProvider serviceProvider)
		{
			using (var context = new shoppingCartDbContext
				(serviceProvider.GetRequiredService<DbContextOptions<shoppingCartDbContext>>()))
			{
				if (context.Pages.Any())
				{
					return;
				}
				context.Pages.AddRange(
					new Page
					{
						Title = "Home",
						Slug = "home",
						Content = "home Page",
						Sorting = 0
					},
				new Page
				{
					Title = "about-us",
					Slug = "AboutUs",
					Content = "about us Page",
					Sorting = 100
				},
				new Page
				{
					Title = "Services",
					Slug = "services",
					Content = "Services Page",
					Sorting = 100
				},
				new Page
				{
					Title = "Contact",
					Slug = "contact",
					Content = "contact Page",
					Sorting = 100
				}
			);
				context.SaveChanges();
			}
		}
	}
}
