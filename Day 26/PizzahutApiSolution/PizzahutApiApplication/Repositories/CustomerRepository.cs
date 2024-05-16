using Microsoft.EntityFrameworkCore;
using PizzahutApiApplication.Context;
using PizzahutApiApplication.Interfaces;
using PizzahutApiApplication.Models;

namespace PizzahutApiApplication.Repositories
{
    public class CustomerRepository : IRepository<int,Customer>
    {
        PizzahutContext _context;
        public CustomerRepository(PizzahutContext context)
        {
            _context = context;
        }

        public async Task<Customer> Add(Customer entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
            throw new NotImplementedException();
        }

        public async Task<Customer> Delete(int id)
        {
            var customer = await Get(id);
            if (customer != null)
            {
                _context.Remove(customer);
                await _context.SaveChangesAsync();
            }
            throw new NotImplementedException();
        }

        public async Task<Customer> Get(int id)
        {
            var result = _context.Customers.FirstOrDefault(c=>c.Id == id);
            return result;
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Customer>> Get()
        {
            return await _context.Customers.ToListAsync();
            throw new NotImplementedException();
        }

        public async Task<Customer> Update(Customer entity)
        {
            var customer = await Get(entity.Id);
            if (customer != null)
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();
                return customer;
            }
            throw new NotImplementedException();
        }
    }
}
