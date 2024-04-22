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
            throw new DuplicateCustomerException();
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

        public List<int> GetCustomerBooksWithId(int id)
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

        public Customer AddBookToCustomer(int CustomerId, int BookId)
        {
            List<Customer> customers = _customerRepository.GetAll();
            foreach (var customer in customers) { if(customer.Id == CustomerId)
                {
                    customer.BooksTaken.Add(BookId);
                    return customer;
                } 
            }
            throw new CannotFindTheObjectException();
        }
        public Customer RemoveBookToCustomer(int CustomerId, int BookId)
        {
            List<Customer> customers = _customerRepository.GetAll();
            foreach (var customer in customers)
            {
                if (customer.Id == CustomerId)
                {
                    customer.BooksTaken.Remove(BookId);
                    return customer;
                }
            }
            throw new CannotFindTheObjectException();
        }
    }
}
