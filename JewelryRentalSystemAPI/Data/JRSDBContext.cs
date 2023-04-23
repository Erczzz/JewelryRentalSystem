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
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentType> AppointmentTypes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ScheduleTime> ScheduleTimes { get; set; }
        public DbSet<CustomerClassification> CustomerClassifications { get; set; }
    }

}
