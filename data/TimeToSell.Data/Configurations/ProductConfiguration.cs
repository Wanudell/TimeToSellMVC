using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeToSell.Data.Entities;

namespace TimeToSell.Data.Configurations
{
    public class ProductConfiguration : BaseMap<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.ProductName).HasMaxLength(64).IsRequired(true);
            builder.Property(x => x.CompanyName).IsRequired(true);
            builder.Property(x => x.Price).IsRequired(true);
            builder.Property(x => x.ProductDescription).IsRequired(false);
        }
    }
}