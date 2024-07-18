using AzureLearnApplication.Models;

namespace AzureLearnApplication.Interfaces
{
    public interface IProductServices
    {
        public Task<Product> GetById(int ProductId);
        public Task<IEnumerable<Product>> GetAll();
    }
}
