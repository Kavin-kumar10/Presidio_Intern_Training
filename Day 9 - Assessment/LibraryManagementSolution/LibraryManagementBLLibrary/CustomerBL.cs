using LibraryManagementDALLibrary;
using LibraryManagementModals;
using LibraryManagmentModals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementBLLibrary
{
    public class CustomerBL : ICustomerServices
    {
        IRepository<int, Customer> _customerRepository;

        public CustomerBL()
        {
            _customerRepository = new CustomerRepository();
        }
        public Customer AddCustomer(Customer item)
        {
            throw new NotImplementedException();
        }

        public Customer DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public List<Book> GetCustomerBooksWithId(int id)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public Customer UpdateCustomer(Customer item)
        {
            throw new NotImplementedException();
        }
    }
}
