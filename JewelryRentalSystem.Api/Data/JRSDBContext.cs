
using JewelryRentalSystem.Api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JewelryRentalSystem.Api.Data
{
    public class JRSDBContext : IdentityDbContext
    {
        public JRSDBContext(DbContextOptions<JRSDBContext> options) : base(options) 
        { 
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CustomerClassification> CustomerClassifications { get; set; }
    }

}
