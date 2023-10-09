using Microsoft.EntityFrameworkCore;
using WebApp.Entities;

namespace WebApp.Context
{
	public class AppDb:DbContext
	{
        public AppDb(DbContextOptions options):base(options) { }
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
    }
}
