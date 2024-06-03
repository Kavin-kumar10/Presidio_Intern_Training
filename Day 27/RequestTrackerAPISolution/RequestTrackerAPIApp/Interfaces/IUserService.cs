using RequestTrackerAPIApp.Modals;
using RequestTrackerAPIApp.Modals.DTOs;

namespace RequestTrackerAPIApp.Interfaces
{
    public interface IUserService
    {
        public Task<LoginReturnDTO> Login(UserLoginDTO loginDTO);
        public Task<Employee> Register(EmployeeUserDTO employeeDTO);
    }
}
