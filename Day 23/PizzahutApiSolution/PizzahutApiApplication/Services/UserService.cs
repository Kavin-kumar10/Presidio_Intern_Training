using PizzahutApiApplication.Interfaces;
using PizzahutApiApplication.Models;
using PizzahutApiApplication.Models.DTOs;
using RequestTrackerAPIApp.Exceptions;
using System.Security.Cryptography;
using System.Text;

namespace PizzahutApiApplication.Services
{
    public class UserService : IUserService
    {
        readonly private IRepository<int, Customer> _customerRepository;
        readonly private IRepository<int, User> _userRepository;

        public UserService(IRepository<int,Customer> customerRepository,IRepository<int,User> userRepository) {
            _customerRepository = customerRepository;
            _userRepository = userRepository;
            
        }
        public async Task<Customer> Login(UserLoginDTO userdto)
        {
            var userDB = await _userRepository.Get(userdto.Id);
            if (userDB == null)
            {
                throw new UnauthorizedUserException("Invalid username or password");
            }
            HMACSHA512 hMACSHA = new HMACSHA512(userDB.PasswordHashKey);
            var encrypterPass = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(userdto.Password));
            bool isPasswordSame = ComparePassword(encrypterPass, userDB.Password);
            if (isPasswordSame)
            {
                var employee = await _customerRepository.Get(userdto.Id);
                if (userDB.Status == "Active")
                    return employee;
                throw new UserNotActiveException("Your account is not activated");
            }
            throw new UnauthorizedUserException("Invalid username or password");
        }

        private bool ComparePassword(byte[] encrypterPass, byte[] password)
        {
            for (int i = 0; i < encrypterPass.Length; i++)
            {
                if (encrypterPass[i] != password[i])
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<Customer> Register(CustomerDTO customerdto)
        {
            Customer customer = null;
            User user = null;
            try
            {
                customer = customerdto;
                customer = await _customerRepository.Add(customer);
                user = MapCustomerUserDTOToUser(customerdto,customer);
                user = await _userRepository.Add(user);
                ((CustomerDTO)customer).Password = string.Empty;
                return customer;
            }
            catch (Exception) { }
            if(customer != null)
            {
                await RevertCustomerInsert(customer);
            }
            if(user != null)
            {
                await RevertUserInsert(user);
            }
            throw new UnableToRegisterException("Not able to register at this moment");
        }

        private async Task RevertUserInsert(User user)
        {
            await _customerRepository.Delete(user.CustomerId);
        }

        private async Task RevertCustomerInsert(Customer customer)
        {
            await _customerRepository.Delete(customer.Id);
        }

        public User MapCustomerUserDTOToUser(CustomerDTO customerdto,Customer customer)
        {
            User user = new User();
            user.CustomerId = customer.Id;
            user.Status = "Disabled";
            HMACSHA512 hMACSHA = new HMACSHA512();
            user.PasswordHashKey = hMACSHA.Key;
            user.Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(customerdto.Password));
            return user;
        }
    }
}
