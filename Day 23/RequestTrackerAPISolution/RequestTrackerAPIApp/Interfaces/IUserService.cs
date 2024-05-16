using RequestTrackerAPIApp.Modals;
using RequestTrackerAPIApp.Modals.DTOs;

namespace RequestTrackerAPIApp.Interfaces
{
    public interface IUserService
    {
        public  Task<Employee> Login(UserLoginDTO loginDTO);
        public Task<Employee> Register(EmployeeUserDTO employeeDTO);
    }
}
