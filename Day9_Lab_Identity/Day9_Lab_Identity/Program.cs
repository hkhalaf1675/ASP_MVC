using Day9_Lab_Identity.Models.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = new ConfigurationBuilder()
       .SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("appsettings.json")
       .Build();

// Add services to the container.
builder.Services.AddControllersWithViews();

var shopDbConnection = builder.Configuration.GetConnectionString("ShopDbConnection");
builder.Services.AddDbContext<ShopDbContext>(option => option.UseSqlServer(shopDbConnection));

builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<ShopDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

// authentication : to check the user authentications
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
