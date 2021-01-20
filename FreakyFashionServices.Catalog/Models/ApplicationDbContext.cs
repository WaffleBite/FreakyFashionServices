using FreakyFashionServices.Catalog.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FreakyFashionServices.Catalog.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Product>()
            //    .Property(p => p.Price)
            //    .HasColumnType("decimal(18,2)");

            SeedProducts(modelBuilder);
        }

        private static void SeedProducts(ModelBuilder modelBuilder)
        {
            var products = new List<Product>
            {
                new Product(1, "ABC123", "White T-shirt", "Must have basic t-shirt.", 200, 25),
                new Product(2, "BCA123", "Black T-shirt", "Must have basic t-shirt.", 200, 20),
                new Product(3, "AAA123", "Pink T-shirt", "Must have basic t-shirt.", 200, 34),
                new Product(4, "BBB123", "Casual Black Dress", "A casual black dress.", 590, 4),
                new Product(5, "CCC123", "Dotted Shirt", "A nice shirt for parties.", 365, 17),
            };
            products.ForEach(x => modelBuilder.Entity<Product>().HasData(x));
        }
    }
}
