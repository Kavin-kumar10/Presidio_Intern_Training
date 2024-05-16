using PizzahutApiApplication.Models;

namespace PizzahutApiApplication.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(Customer customer);
    }
}
