using ShoppingModalLibrary.cs;

namespace ShoppingBLLibrary
{
    public interface ICustomerServices
    {
        Task<List<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(int id);
        Task<int> AddCustomer(Customer customer);
        Task<int> UpdateCustomer(Customer customer);
        Task<Customer> DeleteCustomer(int id);

    }
}
