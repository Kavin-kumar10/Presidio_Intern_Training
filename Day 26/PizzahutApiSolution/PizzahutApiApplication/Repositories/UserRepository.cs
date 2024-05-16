using Microsoft.EntityFrameworkCore;
using PizzahutApiApplication.Context;
using PizzahutApiApplication.Interfaces;
using PizzahutApiApplication.Models;

namespace PizzahutApiApplication.Repositories
{
    public class UserRepository : IRepository<int,User>
    {
        PizzahutContext _context;
        public UserRepository(PizzahutContext context)
        {
            _context = context;
        }

        public async Task<User> Add(User entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
            throw new NotImplementedException();
        }

        public async Task<User> Delete(int id)
        {
            var user = await Get(id);
            if (user != null)
            {
                _context.Remove(user);
                await _context.SaveChangesAsync();
            }
            throw new NotImplementedException();
        }

        public async Task<User> Get(int id)
        {
            var result = _context.Users.FirstOrDefault(u => u.CustomerId == id);
            return result;
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> Get()
        {
            return await _context.Users.ToListAsync();
            throw new NotImplementedException();
        }

        public async Task<User> Update(User entity)
        {
            var user = await Get(entity.CustomerId);
            if (user != null)
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();
                return user;
            }
            throw new NotImplementedException();
        }
    }
}
