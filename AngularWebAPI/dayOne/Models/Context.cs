using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace dayOne.Models
{
	public class Context:IdentityDbContext<ApplicationUser>
	{
		public Context() { }
		public Context(DbContextOptions dbContextOptions):base(dbContextOptions) 
		{
		}
		public DbSet<ApplicationUser> applicationUser { get; set; }
		public DbSet<Cart> Cart { get; set; }
		public DbSet<Order> Order { get; set; }
		public DbSet<Category> Category { get; set; }
		public DbSet<Customer> Customer { get; set; }
		public DbSet<OrderProducts> OrderProducts { get; set; }
		public DbSet<Product> Product { get; set; }
		public DbSet<ProductCart> productCart { get; set; }
		public DbSet<Report> Reports { get; set; }
		public DbSet<Seller> Seller { get; set; }
		public DbSet<Shipper> Shipper { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<Product>().OwnsMany(
				product => product.AdditionalFeature, OwnedNavigationBuilder =>
				{
					OwnedNavigationBuilder.ToJson();

				}
				);
				base.OnModelCreating(modelBuilder);

        }




    }
}
