using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Models;
using Demo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Product>> GetAllProducts()
            => await _productService.GetAllProducts();

        [HttpPost]
        public async Task<int?> AddProduct(string name, double price)
            => await _productService.AddProduct(name, price);

        [HttpDelete]
        public async Task<int> DeleteProduct(int id)
            => await _productService.DeleteProduct(id);

    }
}
