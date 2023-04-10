using JewelryRentalSystem.Models;
using JewelryRentalSystem.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.Xml.Linq;
using JewelryRentalSystem.Data.EntityRelationship;

namespace JewelryRentalSystem.Data
{
/* We have to input the <ApplicationUser> in our IdentityDbContext
 * for us to be able to work in our custom columns or property in AspNetUsers*/
    public class JRSDBContext : IdentityDbContext<ApplicationUser>
    {
        public JRSDBContext(DbContextOptions<JRSDBContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string con = "Server = (localdb)\\MSSQLLocalDB; " +
                "Database = JRSDB; Integrated Security = true;";
            optionsBuilder.UseSqlServer(con)
                .UseQueryTrackingBehavior(QueryTrackingBehavior
                .NoTracking);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedAdminUser();
            modelBuilder.SeedDefaultTime();

            modelBuilder.ProductCategoryRelation();
            modelBuilder.AppointmentTimeRelation();
            modelBuilder.LocationAppointmentrelation();
            base.OnModelCreating(modelBuilder);
            
        }

        public DbSet<User> Users { get; set; }
/*        public DbSet<Role> Roles { get; set; }*/
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentType> AppointmentTypes { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<ScheduleTime> ScheduleTimes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<JewelryRentalSystem.ViewModels.ProfileViewModel>? ProfileViewModel { get; set; }
    }
}
