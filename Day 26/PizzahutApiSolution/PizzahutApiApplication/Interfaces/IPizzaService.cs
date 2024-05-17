using PizzahutApiApplication.Models;

namespace PizzahutApiApplication.Interfaces
{
    public interface IPizzaService
    {
        public Task<Pizza> GetById(int id);
        public Task<IEnumerable<Pizza>> GetAllPizza();
        public Task<IEnumerable<Pizza>> GetAllAvailablePizza();
        public Task<Pizza> CreatePizza(Pizza pizza);
    }
}
