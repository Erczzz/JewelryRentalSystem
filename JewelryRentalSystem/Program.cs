using JewelryRentalSystem.Data;
using JewelryRentalSystem.Helpers;
using JewelryRentalSystem.Models;
using JewelryRentalSystem.Repository;
using JewelryRentalSystem.Repository.MsSQL;
using JewelryRentalSystem.Services;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<JRSDBContext>();

builder.Services.AddScoped<JRSDBContext, JRSDBContext>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<JRSDBContext>();


builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 5;
    options.Password.RequiredUniqueChars = 1;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
});

builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = "/login";
});

builder.Services.AddScoped<IProductDBRepository, ProductDBRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ApplicationUserClaimsPrincipalFactory>();


var app = builder.Build();
{
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
    }
}

app.UseStaticFiles();

app.AutoMigrate();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

// Hello changes
/*app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "cartCount",
        pattern: "Cart/GetCartCount",
        defaults: new { controller = "Cart", action = "GetCartCount" });
    // add other routes as needed
});*/

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=GetAllProducts}/{id?}");

app.Run();
