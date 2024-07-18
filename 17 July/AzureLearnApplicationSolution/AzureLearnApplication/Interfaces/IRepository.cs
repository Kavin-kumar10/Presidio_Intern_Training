using AzureLearnApplication.Models;

namespace AzureLearnApplication.Interfaces
{
    public interface IRepository<k,T> where T : class 
    {
        public Task<IEnumerable<T>> GetProducts();
        public Task<T> GetProduct(int productId);
    }
}
