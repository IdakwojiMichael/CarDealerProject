using CarDealerProject.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//  Load appsettings.Production.json if in Production
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true);

// Add services to the container
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

// Configure SQL Server with connection string
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CarDealerProjectConnectionString")));

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseSession(); // Enable session

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
