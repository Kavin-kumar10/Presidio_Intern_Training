using ExceptionHandling;
using ShoppingDALLibrary;
using ShoppingModalLibrary.cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public class CustomerBL : ICustomerServices
    {
        readonly IRepository<int, Customer> _customerrepository;

        public CustomerBL(CustomerRepository customerrepository)
        {
            _customerrepository = customerrepository;
        }

        public int AddCustomer(Customer customer)
        {
            var result = _customerrepository.Add(customer);
            if (result != null) { return result.Id; }
            throw new DuplicateItemFoundException();
        }

        public Customer DeleteCustomer(int id)
        {
            var result = _customerrepository.Delete(id); 
            if (result != null) { return result; }
            throw new NoCustomerWithGiveIdException();
        }

        public List<Customer> GetAllCustomers()
        {
            var result = _customerrepository.GetAll();
            if(result != null) { return result.ToList(); };
            throw new NoCustomerWithGiveIdException();
        }

        public Customer GetCustomerById(int id)
        {
            var result = _customerrepository.GetByKey(id);
            if (result != null) return result;
            throw new NoCustomerWithGiveIdException();
        }

        public int UpdateCustomer(Customer customer)
        {
            var result = _customerrepository.Update(customer);
            if(result != null) { return result.Id; };
            throw new NoCustomerWithGiveIdException();
        }
    }
}
