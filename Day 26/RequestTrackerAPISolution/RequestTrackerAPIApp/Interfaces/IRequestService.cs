using RequestTrackerAPIApp.Modals;

namespace RequestTrackerAPIApp.Interfaces
{
    public interface IRequestService
    {
        public Task<Request> Raise_Request(Request request);
        public Task<IEnumerable<Request>> ShowRequests();
        public Task<IEnumerable<Request>> ShowMyRequests(int employeeId);

    }
}
