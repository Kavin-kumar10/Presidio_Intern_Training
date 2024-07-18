using AzureLearnApplication.Interfaces;
using AzureLearnApplication.Models;
using AzureLearnApplication.Repository;

namespace AzureLearnApplication.Services
{
    public class ProductService : IProductServices
    {
        private IRepository<int,Product> _repo;

        public ProductService(IRepository<int,Product> repo) {
            _repo = repo;
        } 
        public async Task<IEnumerable<Product>> GetAll()
        {
            try
            {
                var result = await _repo.GetProducts();
                return result;
            }
            catch(Exception ex){ 
            }
            throw new Exception("Unable to find any product");
        }

        public async Task<Product> GetById(int ProductId)
        {
            try
            {
                var result = await _repo.GetProduct(ProductId);
                return result;
            }
            catch (Exception ex)
            {
            }
            throw new Exception("No such product exist");
        }
    }
}
