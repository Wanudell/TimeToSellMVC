using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TimeToSell.Common;
using TimeToSell.Data.Entities;
using TimeToSell.Data.Entity;

namespace TimeToSell.Seed
{
    public static class SeedData
    {
        public static async Task SeedUser(UserManager<User> userManager)
        {
            if (userManager.Users.Any())
            {
                await Task.CompletedTask;
                return;
            }

            var user = new User()
            {
                FirstName = "Sys",
                LastName = "Admin",
                Email = "sysadmin@timetosell.com",
                UserName = "sysadmin",
                BirthDate = DateTime.Now
            };

            await userManager.CreateAsync(user, "SysAdmin1.");

            await userManager.AddToRoleAsync(user, "SysAdmin");

            user = new User()
            {
                FirstName = "Admin",
                LastName = "Admin",
                Email = "admin@timetosell.com",
                UserName = "admin",
                BirthDate = DateTime.Now
            };

            await userManager.CreateAsync(user, "Admin1.");

            await userManager.AddToRoleAsync(user, "Admin".ToUpper(new System.Globalization.CultureInfo("en-US")));

            user = new User()
            {
                FirstName = "Kot",
                LastName = "Pantelon",
                UserName = "OMemo",
                Email = "kotpantelon@timetosell.com",
                BirthDate = DateTime.Now
            };

            await userManager.CreateAsync(user, "Customer1.");

            await userManager.AddToRoleAsync(user, "Customer".ToUpper(new System.Globalization.CultureInfo("en-US")));
        }

        public static async Task SeedRole(RoleManager<IdentityRole<Guid>> roleManager)
        {
            if (roleManager.Roles.Any())
            {
                await Task.CompletedTask;
                return;
            }

            await roleManager.CreateAsync(new IdentityRole<Guid>("SysAdmin"));
            await roleManager.CreateAsync(new IdentityRole<Guid>("Admin"));
            await roleManager.CreateAsync(new IdentityRole<Guid>("Customer"));
        }

        public static async void SeedProduct(TimeToSellDbContext context)
        {
            if (context.Products.Any())
            {
                await Task.CompletedTask;
                return;
            }
            context.Products.Add(new Product()
            {
                ProductName = "Bilgisayar",
                ProductDescription = "Bilgi saymakla hükümlü bu cihaz yüzyılın icadıdır...",
                CompanyName = "Kod Company"
            });
            context.Products.Add(new Product()
            {
                ProductName = "Telefon",
                ProductDescription = "Ulaşım ile hükümlü bu cihaz yüzyılın icatları arasındandır...",
                CompanyName = "TeleCompany"
            });

            context.SaveChanges();
        }
    }
}