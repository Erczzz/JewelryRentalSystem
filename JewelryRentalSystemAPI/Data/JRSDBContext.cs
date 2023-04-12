using JewelryRentalSystemAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JewelryRentalSystemAPI.Data
{
    public class JRSDBContext : IdentityDbContext<ApplicationUser>
    {
        public JRSDBContext(DbContextOptions<JRSDBContext> options) : base(options) 
        { 
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }

}
