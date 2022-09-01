using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeToSell.Data.Dtos
{
    public class ProductListDto
    {
        public string ProductName { get; set; }
        public Guid ProductId { get; set; }
        public string CompanyName { get; set; }
        public decimal Price { get; set; }
    }
}