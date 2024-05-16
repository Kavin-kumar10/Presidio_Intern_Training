using PizzahutApiApplication.Models;

namespace PizzahutApiApplication.Interfaces
{
    public interface IPizzaService
    {
        public Task<IEnumerable<Pizza>> GetAllPizza();
        public Task<IEnumerable<Pizza>> GetAllAvailablePizza();
    }
}
