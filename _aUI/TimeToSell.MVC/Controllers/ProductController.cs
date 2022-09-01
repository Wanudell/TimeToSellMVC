using Microsoft.AspNetCore.Mvc;
using TimeToSell.MVC.Models;
using TimeToSell.Services.Abstractions;

namespace TimeToSell.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult ListProducts([FromServices] IProductService productService)
        {
            var products = productService.GetProducts();
            var vm = new ProductListViewModel
            {
                Items = products
            };
            return View(vm);
        }
    }
}