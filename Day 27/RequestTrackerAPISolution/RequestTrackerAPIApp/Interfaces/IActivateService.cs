using RequestTrackerAPIApp.Modals;
using RequestTrackerAPIApp.Modals.DTOs;

namespace RequestTrackerAPIApp.Interfaces
{
    public interface IActivateService
    {
        Task<ActivateDTO> ActivateEmployee(int  employeeId);
        Task<ActivateDTO> DeActivateEmployee(int employeeId);
    }
}
