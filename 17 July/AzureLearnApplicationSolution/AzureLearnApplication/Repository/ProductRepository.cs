using AzureLearnApplication.Context;
using AzureLearnApplication.Interfaces;
using AzureLearnApplication.Models;

namespace AzureLearnApplication.Repository
{
    public class ProductRepository : IRepository<int, Product>
    {
        private DbProductContext _context;

        public ProductRepository(DbProductContext context) { 
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return _context.Products;
        }

        public async Task<Product> GetProduct(int productId)
        {
            var result = await _context.Products.FindAsync(productId);
            return result;
        }
    }
}
