using JewelryRentalSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JewelryRentalSystem.Data
{
    public static class SeedData
    {
        public static void SeedAdminUser(this ModelBuilder modelBuilder)
        {
            var admin_RoleId = "9ea94376-bae3-4592-b2ef-16e2222ec6f4";
            var cust_RoleId = "f913644d-d5a1-4c4a-a73b-dacc6a8c7898";
            string user_AdminId = "02174cf0–9412–4cfe-afbf-59f706d72cf6";
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {

                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                Id = admin_RoleId,
                ConcurrencyStamp = admin_RoleId
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
            user.PasswordHash = ph.HashPassword(user, "password1!");

            //seed user
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = admin_RoleId,
                UserId = user_AdminId
            });
        }

        public static void SeedDefaultTime(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ScheduleTime>().HasData(
                new ScheduleTime(1, "8:00:00 - 9:00:00"),
                new ScheduleTime(2, "9:00:00 - 10:00:00"),
                new ScheduleTime(3, "10:00:00 - 11:00:00"),
                new ScheduleTime(4, "11:00:00 - 12:00:00"),
                new ScheduleTime(5, "13:00:00 - 14:00:00"),
                new ScheduleTime(6, "14:00:00 - 15:00:00"),
                new ScheduleTime(7, "15:00:00 - 16:00:00"),
                new ScheduleTime(8, "16:00:00 - 17:00:00")
                );

        }


    }
}
