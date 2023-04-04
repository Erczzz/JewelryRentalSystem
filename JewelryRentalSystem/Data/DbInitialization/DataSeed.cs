using JewelryRentalSystem.Models;
using Microsoft.AspNetCore.Identity;

namespace JewelryRentalSystem.Data.DbInitialization
{
    public static class DataSeed
    {
        public static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (roleManager.Roles.Any())
            {
                return;
            }

            string[] roles = new[] { "Administrator", "Employer", "Cystomer" };

            foreach (string role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        public static async Task SeedAdminUser(UserManager<ApplicationUser> userManager)
        {
            if (userManager.Users.Any())
            {
                return;
            }

            var admin = new ApplicationUser
            {
                UserName = "admin@pjli.com",
                Email = "admin@pjli.com",
                FirstName = "Administrator",
                LastName = "Admin",
                Birthdate = new DateTime(1999, 2, 12),
                ContactNo = "09876543210",
                Address = "Sample Address"
            };

            var result = await userManager.CreateAsync(admin, "Admin1!");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, "Administrator");
            }
            else
            {
                throw new InvalidOperationException("Failed to generate admin user.");
            }
        }

    }
}
