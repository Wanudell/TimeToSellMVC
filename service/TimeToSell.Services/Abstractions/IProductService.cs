using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeToSell.Data.Dtos;

namespace TimeToSell.Services.Abstractions
{
    public interface IProductService
    {
        List<ProductListDto> GetProducts();
    }
}