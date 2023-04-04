using JewelryRentalSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace JewelryRentalSystem.Data
{
    public class SeedData
    {
        private JRSDBContext _context;

        public SeedData(JRSDBContext context)
        {
            _context = context;
        }

        public async void SeedAdminUser()
        {
            var user = new ApplicationUser
            {
                UserName = "Email@email.com",
                NormalizedUserName = "email@email.com",
                Email = "Email@email.com",
                NormalizedEmail = "email@email.com",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                FirstName = "Admin",
                LastName = "Admin",
                Birthdate = new DateTime(1999, 2, 12),
                ContactNo = "09920098321",
                Address = "SampleAddress"

            };

            var roleStore = new RoleStore<IdentityRole>(_context);

            if (!_context.Roles.Any(r => r.Name == "admin"))
            {
                await roleStore.CreateAsync(new IdentityRole { Name = "admin", NormalizedName = "admin" });
            }

            if (!_context.Users.Any(u => u.Username == user.UserName))
            {
                var password = new PasswordHasher<ApplicationUser>();
                var hashed = password.HashPassword(user, "password");
                user.PasswordHash = hashed;
                var userStore = new UserStore<ApplicationUser>(_context);
                await userStore.CreateAsync(user);
                await userStore.AddToRoleAsync(user, "admin");
            }

            await _context.SaveChangesAsync();
        }
    }
}
