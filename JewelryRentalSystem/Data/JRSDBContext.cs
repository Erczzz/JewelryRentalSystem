using JewelryRentalSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace JewelryRentalSystem.Data
{
    public class JRSDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string con = "Server = (localdb)\\MSSQLLocalDB; Database = JRSDB; Integrated Security = true;";
            optionsBuilder.UseSqlServer(con).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentType> AppointmentTypes { get; set;}
        public DbSet<Payment> Payments { get; set; }
    }
}
