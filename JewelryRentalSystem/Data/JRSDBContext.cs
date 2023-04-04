using JewelryRentalSystem.Models;
using JewelryRentalSystem.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JewelryRentalSystem.Data
{
/* We have to input the <ApplicationUser> in our IdentityDbContext
 * for us to be able to work in our custom columns or property in AspNetUsers*/
    public class JRSDBContext : IdentityDbContext<ApplicationUser>
    {
        public JRSDBContext()
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
            modelBuilder.Entity<User>()
                .HasOne<Role>(x => x.Roles)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);
/*
            var adminRole = new RoleViewModel { Name = "Administrator" };
            var employeeRole = new RoleViewModel { Name = "Employee" };
            var customerRole = new RoleViewModel { Name = "Customer" };

            modelBuilder.Entity<RoleViewModel>()
                .HasData(adminRole, employeeRole, customerRole);

            modelBuilder.Entity<ApplicationUser>()
                .HasData(new ApplicationUser
                {
                    FirstName = "Admin",
                    LastName = "Admin",
                    Birthdate = new DateTime(1999, 2, 12),
                    ContactNo = "09920098321",
                    Email = "admin@email.com",
                    Address = "SampleAddress",
                });*/
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentType> AppointmentTypes { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
