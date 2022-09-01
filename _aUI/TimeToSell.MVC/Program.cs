using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TimeToSell.Common;
using TimeToSell.Data.Entities;
using TimeToSell.Data.Entity;
using TimeToSell.Seed;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TimeToSellDbContext>();

builder.Services.AddIdentity<User, IdentityRole<Guid>>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<TimeToSellDbContext>();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = new PathString("/home/login");
});
var app = builder.Build();
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
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<TimeToSellDbContext>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

    context.Database.EnsureCreated();
    SeedData.SeedRole(roleManager).GetAwaiter().GetResult();
    SeedData.SeedUser(userManager).GetAwaiter().GetResult();
    SeedData.SeedProduct(context);
}

app.Run();