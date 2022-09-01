using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TimeToSell.Data.Configurations;
using TimeToSell.Data.Entities;
using TimeToSell.Data.Entity;

namespace TimeToSell.Common
{
    public class TimeToSellDbContext : IdentityDbContext<User>
    {
        public TimeToSellDbContext(DbContextOptions<TimeToSellDbContext> options) : base(options)
        {
            //private readonly IHttpContextAccessor context;
        }

        public DbSet<Product> Products { get; set; }

        // public TimeToSellDbContext(DbContextOptions<TimeToSellDbContext> options, IHttpContextAccessor context) : base(options)
        //{
        //    this.context = context;
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductConfiguration());
            //builder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(builder);
        }

        //public override int SaveChanges()
        //{
        //    var entries = ChangeTracker.Entries<BaseEntity>();

        //    foreach (var entry in entries)
        //    {
        //        if (entry.State == EntityState.Added)
        //        {
        //            entry.Entity.CreatedAt = DateTime.Now;
        //            entry.Entity.CreatedBy = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        //        }

        //        if (entry.State == EntityState.Modified)
        //        {
        //            entry.Entity.ModifiedBy = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        //            entry.Entity.ModifiedAt = DateTime.Now;
        //        }
        //    }

        //    return base.SaveChanges();
        //}
    }
}