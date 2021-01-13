using FreakyFashionServices.Catalog.Models.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace FreakyFashionServices.Catalog.Models
{
    public class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<ApplicationDbContext>());
            }
        }

        public static void SeedData(ApplicationDbContext context)
        {
            System.Console.WriteLine("Applying Migrations...");

            context.Database.Migrate();

            //check if we have products in the database
            if (!context.Products.Any())
            {
                Console.WriteLine("Adding data - seeding...");
                context.Products.AddRange(
                    new Product()
                    {
                        Name = "White T-shirt",
                        Description = "Must have basic t-shirt",
                        Price = 344,
                        AvailableStock = 20
                    },
                    new Product()
                    {
                        Name = "Black T-shirt",
                        Description = "Must have basic t-shirt",
                        Price = 344,
                        AvailableStock = 25
                    },
                    new Product()
                    {
                        Name = "Black Dress",
                        Description = "Basic, elegant black dress",
                        Price = 560,
                        AvailableStock = 6
                    }
                 );
                context.SaveChanges();
            }
            else
            {
                Console.Write("Already has data - not seeding");
            }
        }
    }
}
