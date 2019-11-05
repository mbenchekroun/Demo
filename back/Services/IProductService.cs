using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Models;

namespace Demo.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts();

        Task<int?> AddProduct(string name, double price);
        Task<int> DeleteProduct(int id);
    }
}
