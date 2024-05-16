using Microsoft.EntityFrameworkCore;
using PizzahutApiApplication.Context;
using PizzahutApiApplication.Interfaces;
using PizzahutApiApplication.Models;

namespace PizzahutApiApplication.Repositories
{
    public class PizzaRepository : IRepository<int, Pizza>
    {
        PizzahutContext _context;
        public PizzaRepository(PizzahutContext context)
        {
            _context = context;
        }

        public async Task<Pizza> Add(Pizza entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
            throw new NotImplementedException();
        }

        public async Task<Pizza> Delete(int id)
        {
            var pizza = await Get(id);
            if (pizza != null)
            {
                _context.Remove(pizza);
                await _context.SaveChangesAsync();
            }
            throw new NotImplementedException();
        }

        public async Task<Pizza> Get(int id)
        {
            var result = _context.Pizzas.FirstOrDefault(p => p.PizzaId == id);
            return result;
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Pizza>> Get()
        {
            return await _context.Pizzas.ToListAsync();
            throw new NotImplementedException();
        }

        public async Task<Pizza> Update(Pizza entity)
        {
            var pizza = await Get(entity.PizzaId);
            if(pizza!= null)
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();
                return pizza;
            }
            throw new NotImplementedException();
        }
    }
}
