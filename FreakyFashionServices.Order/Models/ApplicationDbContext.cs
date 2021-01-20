using FreakyFashionServices.Order.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FreakyFashionServices.Order.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Orders { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

    }
}