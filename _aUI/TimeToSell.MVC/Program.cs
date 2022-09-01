using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TimeToSell.Common;
using TimeToSell.Data.Entity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

var settingSection = builder.Configuration.GetSection("Settings");
var settings = settingSection.Get<TimeToSellSettings>();

builder.Services.Configure<TimeToSellSettings>(settingSection);
builder.Services.AddDbContext<TimeToSellDbContext>(options =>
{
    options.UseSqlServer(settings.Database.ConnectionString);
});

builder.Services.AddIdentity<User, IdentityRole>()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<TimeToSellDbContext>();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();