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
        readonly private ITokenService _tokenservice;

        public UserService(IRepository<int,Customer> customerRepository,IRepository<int,User> userRepository,ITokenService tokenService) {
            _customerRepository = customerRepository;
            _userRepository = userRepository;
            _tokenservice = tokenService;


        }
        public async Task<LoginReturnDTO> Login(UserLoginDTO userdto)
        {
            var userDB = await _userRepository.Get(userdto.Id);
            if (userDB == null)
            {
                throw new UnauthorizedUserException("Invalid userid or password");
            }
            HMACSHA512 hMACSHA = new HMACSHA512(userDB.PasswordHashKey);
            var encrypterPass = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(userdto.Password));
            bool isPasswordSame = ComparePassword(encrypterPass, userDB.Password);
            if (isPasswordSame)
            {
                var customer = await _customerRepository.Get(userdto.Id);
                //if (userDB.Status == "Active")
                //{
                LoginReturnDTO loginreturnDTO = MapCustomerToLoginReturnDTO(customer);
                return loginreturnDTO;
                //}
                //throw new UserNotActiveException("Your account is not activated by admin");
            }
            throw new UnauthorizedUserException("Invalid username or password");
        }

        private LoginReturnDTO MapCustomerToLoginReturnDTO(Customer customer)
        {
            LoginReturnDTO loginreturnDTO = new LoginReturnDTO();
            loginreturnDTO.Role = customer.Role;
            loginreturnDTO.CustomerId = customer.Id;
            loginreturnDTO.Token = _tokenservice.GenerateToken(customer);
            return loginreturnDTO;
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
                customer = new Customer() { 
                    Name = customerdto.Name,
                    OrderList = customerdto.OrderList,
                    Phone = customerdto.Phone,
                    Role = customerdto.Role,
                };
                customer = await _customerRepository.Add(customer);
                user = MapCustomerUserDTOToUser(customerdto,customer);
                user = await _userRepository.Add(user);
                //((CustomerDTO)customer).Password = string.Empty;
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
