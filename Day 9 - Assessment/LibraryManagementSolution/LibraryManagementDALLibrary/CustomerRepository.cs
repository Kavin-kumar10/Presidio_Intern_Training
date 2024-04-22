using LibraryManagementModals;
using LibraryManagmentModals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementDALLibrary
{
    public class CustomerRepository : IRepository<int,Customer>
    {
        readonly Dictionary<int, Customer> _customer;

        public CustomerRepository()
        {
            _customer = new Dictionary<int, Customer>();
        }

        public int GenerateId()
        {
            if (_customer.Count == 0) return 0;
            int max = _customer.Keys.Max();
            return ++max;
        }

        public Customer Add(Customer item)
        {
            if (_customer.ContainsKey(item.Id)) return null;
            item.Id = GenerateId();
            _customer.Add(item.Id, item);
            return item;
            throw new NotImplementedException();
        }

        public Customer Delete(int Key)
        {
            if (_customer.ContainsKey(Key))
                _customer.Remove(Key);
            else
                return null;
            throw new NotImplementedException();
        }

        public Customer Get(int Key)
        {
            if (_customer.ContainsKey(Key))
                return _customer[Key];
            return null;
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            return _customer.Values.ToList();
            throw new NotImplementedException();
        }

        public Customer Update(Customer item)
        {
            if (_customer.ContainsKey(item.Id))
            {
                _customer[item.Id] = item;
            }
            throw new NotImplementedException();
        }
    }
}
