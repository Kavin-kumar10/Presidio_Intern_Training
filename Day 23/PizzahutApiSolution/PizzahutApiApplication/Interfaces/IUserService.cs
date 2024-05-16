using PizzahutApiApplication.Models.DTOs;
using PizzahutApiApplication.Models;

namespace PizzahutApiApplication.Interfaces
{
    public interface IUserService
    {
        public Task<Customer> Login(UserLoginDTO userdto);
        public Task<Customer> Register(CustomerDTO customerdto);
    }
}
