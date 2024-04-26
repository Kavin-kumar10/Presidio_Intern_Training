using ShoppingModalLibrary.cs;

namespace ShoppingBLLibrary
{
    public interface ICustomerServices
    {
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        int AddCustomer(Customer customer);
        int UpdateCustomer(Customer customer);
        Customer DeleteCustomer(int id);

    }
}
