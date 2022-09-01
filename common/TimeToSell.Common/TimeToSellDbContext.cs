using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TimeToSell.Data.Configurations;
using TimeToSell.Data.Entities;
using TimeToSell.Data.Entity;

namespace TimeToSell.Common
{
    public class TimeToSellDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public TimeToSellDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetSection("Settings:Database:ConnectionString").Value);
        }

        public DbSet<Product> Products { get; set; }
        public IConfiguration Configuration { get; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductConfiguration());

            base.OnModelCreating(builder);
        }
    }
}