using cmsShoppingCart.Models;

using Microsoft.EntityFrameworkCore;

namespace cmsShoppingCart.Infrastructure
{
	public class shoppingCartDbContext:DbContext
	{
		public shoppingCartDbContext(DbContextOptions<shoppingCartDbContext> options):base(options)
		{

		}

		public DbSet<Page> Pages { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
	}
}
