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
            string user_AdminId2 = "45e23747-27a5-48e9-b7a6-755bfbb86004";
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
                NormalizedEmail = "ADMIN@GMAIL.COM",
                CustClassId = 5
            };

            var user2 = new ApplicationUser
            {
                Id = user_AdminId2,
                Email = "admin2@gmail.com",
                FirstName = "admin",
                LastName = "admin",
                Birthdate = DateTime.Now.AddYears(-20),
                UserName = "admin2@gmail.com",
                ContactNo = "09876543211",
                Address = "Sample Address",
                NormalizedUserName = "ADMIN2@GMAIL.COM",
                NormalizedEmail = "ADMIN2@GMAIL.COM",
                CustClassId = 5
            };

            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = ph.HashPassword(user, "password1!");
            user2.PasswordHash = ph.HashPassword(user2, "Password1!");

            //seed user
            modelBuilder.Entity<ApplicationUser>().HasData(user);
            modelBuilder.Entity<ApplicationUser>().HasData(user2);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = admin_RoleId,
                UserId = user_AdminId
            });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = admin_RoleId,
                UserId = user_AdminId2
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

        public static void SeedDefaultProductCategory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category(1, "Ring"),
                new Category(2, "Necklace"),
                new Category(3, "Bracelet"),
                new Category(4, "Earrings")
            );
        }

        public static void SeedDefaultProduct(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product(1, "Enchanted Disney Fine Jewelry",
                "Add a pop of color and a touch of magical charm to your looks with this pair of Enchanted Disney Fine Jewelry Dangle Earrings. Featuring a 14k rose gold finish, these sterling silver earrings glitter with class and beauty. Glistening Rose De France complement the pure sparkle of 1/10 CTTW of diamonds. With these beautiful earrings, you won't need magic hair that glows when you sing in order to shine.",
                1250, 4, "/products/productImgs/ed1119de-f9af-4fd3-b97f-f75e8af8b9ea_earrings3.webp", 4, 2),
                new Product(2, "Diamond and Red Garnet Snow White Ring",
                "Dress up like your favorite Disney Princess Snow White by wearing this Enchanted Disney Fine Jewelry Sterling Silver and 10K Rose Gold Ring with Diamond Accent and Red Garnet. Evoking the gentle yet stern personality of Disney's first princess, this ring is all about female empowerment. It's the jewel for the independent lady who still loves fashion pretend play but does it in a chic, stylish, and very sophisticated way.",
                2450, 5, "/products/productImgs/ed1119de-f9af-4fd3-b97f-f75e8af8b9ea_earrings3.webp", 1, 2)
                );
        }

        public static void SeedDefaultCustomerClassification(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerClassification>().HasData(
                new CustomerClassification(1, "Classic", 5, 1),
                new CustomerClassification(2, "Silver", 10, 5),
                new CustomerClassification(3, "Gold", 20, 10),
                new CustomerClassification(4, "Platinum", 0, 0),
                new CustomerClassification(5, "Admin", 0, 0)
                );
        }
        public static void SeedDefaultLocation(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>().HasData(
                new Location(1, "Makati City"),
                new Location(2, "Quezon City"),
                new Location(3, "Valenzuela City"),
                new Location(4, "Antipolo City"),
                new Location(5, "Taguig City")
                );
        }

        public static void SeedDefaultAppointmentType(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppointmentType>().HasData(
                new AppointmentType(1, "Pick-Up")
                );
        }

    }
}
