using LibraryManagementModals;
using LibraryManagmentModals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementBLLibrary
{
    public interface ICustomerServices
    {
        List<Customer> GetAllCustomers();
        Customer AddCustomer(Customer item);
        Customer DeleteCustomer(int id);
        Customer GetCustomerById(int id);
        Customer UpdateCustomer(Customer item);
        List<int> GetCustomerBooksWithId(int id);
    }
}
