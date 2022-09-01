using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeToSell.Common;
using TimeToSell.Data.Dtos;
using TimeToSell.Services.Abstractions;

namespace TimeToSell.Services.Concretes
{
    public class ProductService : IProductService
    {
        private readonly TimeToSellDbContext context;

        public ProductService(TimeToSellDbContext context)
        {
            this.context = context;
        }

        public List<ProductListDto> GetProducts()
        {
            return context.Products.Select(s => new ProductListDto
            {
                ProductId = s.Id,
                ProductName = s.ProductName,
                Price = s.Price
            }).ToList();
        }
    }
}