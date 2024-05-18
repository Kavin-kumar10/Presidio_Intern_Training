using RequestTrackerAPIApp.Exceptions;
using RequestTrackerAPIApp.Interfaces;
using RequestTrackerAPIApp.Modals;

namespace RequestTrackerAPIApp.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRepository<int, Request> _requestRepo;

        public RequestService(IRepository<int,Request> requestRepo) {
            _requestRepo = requestRepo;
        }

        public async Task<Request> Raise_Request(Request request)
        {
            var result = await _requestRepo.Add(request);
            if(result != null) {
                return result;
            }
            throw new UnableToAddRequest();
        }

        public async Task<IEnumerable<Request>> ShowMyRequests(int employeeId)
        {
            var result = await _requestRepo.Get();
            result = result.Where(r=>r.RequestRaisedBy == employeeId);
            if (result != null)
            {
                return result;
            }
            throw new NoRequestFound();
        }

        public async Task<IEnumerable<Request>> ShowRequests()
        {
            var result = await _requestRepo.Get();
            if(result != null)
            {
                return result;
            }
            throw new NoRequestFound();
        }
    }
}
