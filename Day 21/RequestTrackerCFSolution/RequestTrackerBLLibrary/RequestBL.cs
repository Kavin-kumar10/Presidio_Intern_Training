using RequestTrackerCFModals;
using RequestTrackerDALibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class RequestBL : IRequestBL
    {
        private readonly IRepository<int, Request> _repository;

        public RequestBL() {
            _repository = new RequestRepository(new RequestTrackerContext());
        }

        public Task<Request> AddRequest(Request request)
        {
            var result = _repository.Add(request);
            return result;
        }

        public Task<IList<Request>> GetAllRequests()
        {
            return _repository.GetAll();
        }

        public Task<Request> GetRequest(int id)
        {
            return _repository.Get(id);
        }

        public Task<Request> RemoveRequest(int id)
        {
            return _repository.Delete(id);
        }

        public Task<Request> UpdateRequest(Request request)
        {
            return _repository.Update(request);
        }
    }
}
