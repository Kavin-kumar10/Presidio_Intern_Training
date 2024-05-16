using RequestTrackerAPIApp.Modals;

namespace RequestTrackerAPIApp.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(Employee employee);
    }
}
