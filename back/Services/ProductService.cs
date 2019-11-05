using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Demo.Models;

namespace Demo.Services
{
    public class ProductService : IProductService
    {
        private readonly IDbConnection _connection;

        public ProductService(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
            => (await _connection.GetListAsync<ProductDto>()).Select(p => new Product
            {
                Id = p.Id,
                Price = p.Price,
                Name = p.Name
            });

        public async Task<int?> AddProduct(string name, double price)
            => await _connection.InsertAsync(new ProductDto
            {
                Price = price,
                Name = name
            });

        public async Task<int> DeleteProduct(int id)
            => await _connection.DeleteAsync<ProductDto>(id);
    }
}
