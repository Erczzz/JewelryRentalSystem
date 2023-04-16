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
   public class JRSDBContext : IdentityDbContext<ApplicationUser>
    {
        public IConfiguration _appConfig { get; }
        public ILogger _logger { get; }
        private readonly IWebHostEnvironment _env;
        public JRSDBContext(IConfiguration appConfig, ILogger<JRSDBContext> logger,
            IWebHostEnvironment env)
        {
            _appConfig = appConfig;
            _logger = logger;
            _env = env;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*string con = "Server = (localdb)\\MSSQLLocalDB; " +
                "Database = JRSDB; Integrated Security = true;";*/
            var server = _appConfig.GetConnectionString("Server");
            var db = _appConfig.GetConnectionString("DB");
            string connectionString;
            if (_env.IsDevelopment())
            {
                connectionString = $"Server={server};Database={db};MultipleActiveResultSets=true";
            }
            else
            {
                var username = _appConfig.GetConnectionString("Username");
                var password = _appConfig.GetConnectionString("Password");
                connectionString = $"Server={server};Database={db};User Id={username};Password={password};MultipleActiveResultSets=true";
            }
            

            // log over here 
            // _logger.LogInformation("Db Connection string: " + connectionString);


            optionsBuilder.UseSqlServer(connectionString)
                .UseQueryTrackingBehavior(QueryTrackingBehavior
                .NoTracking);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedDefaultProduct();
            modelBuilder.SeedDefaultProductCategory();
            modelBuilder.SeedAdminUser();
            modelBuilder.SeedDefaultTime();

            modelBuilder.AppointmentRelation();
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
        public DbSet<JewelryRentalSystem.ViewModels.ProfileViewModel>? ProfileViewModel { get; set; }
        public DbSet<JewelryRentalSystem.ViewModels.ActivateAccountViewModel>? ActivateAccountViewModel { get; set; }
        public DbSet<JewelryRentalSystem.ViewModels.ModifyAccountViewModel>? ModifyAccountViewModel { get; set; }
    }
}
