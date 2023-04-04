using JewelryRentalSystem.Data;
using JewelryRentalSystem.Helpers;
using JewelryRentalSystem.Models;
using JewelryRentalSystem.Repository;
using JewelryRentalSystem.Repository.MsSQL;
using JewelryRentalSystem.Services;
using Microsoft.AspNetCore.Identity;
using JewelryRentalSystem.Data.DbInitialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<JRSDBContext>();

builder.Services.AddDbContext<JRSDBContext>();
// configure identity framework 

builder.Services.AddScoped<JRSDBContext, JRSDBContext>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<JRSDBContext>();

/*builder.Services.AddData(builder.Configuration).AddDbInitializer();*/

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

builder.Services.AddScoped<IRoleDBRepository, RoleDBRepository>();
builder.Services.AddScoped<IProductDBRepository, ProductDBRepository>();
builder.Services.AddScoped<IUserDBRepository, UserDBRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ApplicationUserClaimsPrincipalFactory>();


var app = builder.Build();

{
    await DbInitializer.InitializeDatabase(app.Services);
    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

// Hello changes

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=GetAllProducts}/{id?}");

app.Run();
