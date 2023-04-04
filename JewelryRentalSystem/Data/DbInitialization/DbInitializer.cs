using JewelryRentalSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JewelryRentalSystem.Data.DbInitialization
{
    public class DbInitializer : IDbInitializer
    {

        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<DbInitializer> _logger;
        private readonly JRSDBContext _dbContext;
        public DbInitializer(
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            ILogger<DbInitializer> logger,
            JRSDBContext dbContext)
        {
            _roleManager = roleManager;
            _logger = logger;
            _userManager = userManager;
            _dbContext = dbContext;
        }
        public async Task Initialize()
        {
            _logger.LogInformation("Initializing Database");

            await DataSeed.SeedRoles(_roleManager);
            await DataSeed.SeedAdminUser(_userManager);
        }

        public static async Task InitializeDatabase(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())             
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<JRSDBContext>();

                var pendingMigrations = context.Database.GetPendingMigrations();
                if (pendingMigrations.Any())
                {
                    await context.Database.MigrateAsync();

                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    var dbInitializerService = services.GetRequiredService<IDbInitializer>();

                    await dbInitializerService.Initialize();
                }
            }
        }
    }
}
