using JewelryRentalSystem.Models;
using JewelryRentalSystem.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.Xml.Linq;

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
            modelBuilder.Entity<Product>()
    .HasOne<Category>(x => x.Category)
    .WithMany(x => x.Products)
    .HasForeignKey(x => x.CategoryId)
    .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
            SeedAdminUser(modelBuilder);
        }

        private static void SeedAdminUser(ModelBuilder builder)
        {
            var admin_RoleId = "9ea94376-bae3-4592-b2ef-16e2222ec6f4";
            var emp_RoleId = "7f749ed5-ec6f-410a-9c89-d37c3e498c0c";
            var cust_RoleId = "f913644d-d5a1-4c4a-a73b-dacc6a8c7898";
            string user_AdminId = "02174cf0–9412–4cfe-afbf-59f706d72cf6";
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                Id = admin_RoleId,
                ConcurrencyStamp = admin_RoleId
            },
            new IdentityRole
            {                           
                Name = "Employee",
                NormalizedName = "EMPLOYEE",
                Id = emp_RoleId,
                ConcurrencyStamp = emp_RoleId
            },
            new IdentityRole
            {
                Name = "Customer",
                NormalizedName = "CUSTOMER",
                Id = cust_RoleId,
                ConcurrencyStamp = cust_RoleId
            }
            );

            var user = new ApplicationUser
            {
                Id = user_AdminId,
                Email = "admin@gmail.com",
                FirstName = "admin",
                LastName = "admin",
                UserName = "admin@gmail.com",
                ContactNo = "09876543211",
                Address = "Sample Address",
                NormalizedUserName = "ADMIN@GMAIL.COM",

            };

            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = ph.HashPassword(user, "myPassword1!");

            //seed user
            builder.Entity<ApplicationUser>().HasData(user);

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = admin_RoleId,
                UserId = user_AdminId
            });
        }



        public DbSet<User> Users { get; set; }
/*        public DbSet<Role> Roles { get; set; }*/
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentType> AppointmentTypes { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
