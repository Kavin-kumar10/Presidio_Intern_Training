using ErrorhandlingExceptions;
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
            var result = _customerRepository.Add(item);
            if (result != null) { return result; }
            return null;
            throw new NotImplementedException();
        }

        public Customer DeleteCustomer(int id)
        {
            var customer = _customerRepository.Get(id);
            if (customer != null) { _customerRepository.Delete(id); }
            throw new CannotFindTheObjectException();
        }

        public List<Customer> GetAllCustomers()
        {
            var result = _customerRepository.GetAll();
            if (result != null) { return result; }
            return null;
            throw new NotImplementedException();
        }

        public List<Book> GetCustomerBooksWithId(int id)
        {
            var result = _customerRepository.Get(id);
            if (result != null) { return result.BooksTaken; }
            throw new NotImplementedException();
        }

        public Customer GetCustomerById(int id)
        {
            var result = _customerRepository.Get(id);
            if (result != null) { return result; }
            throw new NotImplementedException();
        }

        public Customer UpdateCustomer(Customer item)
        {
            var customer = _customerRepository.Get(item.Id);
            if (customer != null) { customer = item; }
            return customer;
            throw new NotImplementedException();
        }
    }
}
