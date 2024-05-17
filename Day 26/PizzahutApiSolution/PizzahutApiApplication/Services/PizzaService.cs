using PizzahutApiApplication.Exceptions;
using PizzahutApiApplication.Interfaces;
using PizzahutApiApplication.Models;

namespace PizzahutApiApplication.Services
{
    public class PizzaService : IPizzaService
    {
        readonly private IRepository<int, Pizza> _repository;

        public PizzaService(IRepository<int,Pizza> repository) {
            _repository = repository;
        }   
        public async Task<IEnumerable<Pizza>> GetAllAvailablePizza()
        {
            var AllPizza = await GetAllPizza();
            var result = AllPizza.Where(p=>p.count > 0).ToList();    
            if(result!=null)
            {
                return result;
            }
            throw new NoItemsFoundException();
        }

        public async Task<IEnumerable<Pizza>> GetAllPizza()
        {
            var AllPizza = await _repository.Get();
            if (AllPizza != null)
            {
                return AllPizza.ToList();
            }
            throw new NoItemsFoundException();
        }

        public async Task<Pizza> GetById(int id)
        {
            var Pizza = await _repository.Get(id);
            if(Pizza != null)
            {
                return Pizza;
            }
            throw new NoItemsFoundException();
        }

        public async Task<Pizza> CreatePizza(Pizza pizza)
        {
            var result = await _repository.Add(pizza);
            if(result != null)
            {
                return result;
            }
            throw new CannotCreateItem();

        }
    }
}
