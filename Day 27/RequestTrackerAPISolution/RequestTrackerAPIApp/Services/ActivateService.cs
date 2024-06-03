using RequestTrackerAPIApp.Exceptions;
using RequestTrackerAPIApp.Interfaces;
using RequestTrackerAPIApp.Modals;
using RequestTrackerAPIApp.Modals.DTOs;

namespace RequestTrackerAPIApp.Services
{
    public class ActivateService : IActivateService
    {
        private readonly IRepository<int, User> _userrepo;

        public ActivateService(IRepository<int,User> userrepo) { 
            _userrepo = userrepo;
        }
        public async Task<ActivateDTO> ActivateEmployee(int employeeId)
        {
            User user = await _userrepo.Get(employeeId);
            if (user == null)
            {
                throw new NoSuchEmployeeException();
            }
            user.Status = "Active";
            var res = await _userrepo.Update(user);
            ActivateDTO activateDTO = new ActivateDTO();
            activateDTO.Status = res.Status;
            activateDTO.EmployeeId = res.EmployeeId;
            return activateDTO;
        }
        public async Task<ActivateDTO> DeActivateEmployee(int employeeId)
        {
            User user = await _userrepo.Get(employeeId);
            if (user == null)
            {
                throw new NoSuchEmployeeException();
            }
            user.Status = "Disabled";
            var res = await _userrepo.Update(user);
            ActivateDTO activateDTO = new ActivateDTO();
            activateDTO.Status = res.Status;
            activateDTO.EmployeeId = res.EmployeeId;
            return activateDTO;
        }
    }
}
