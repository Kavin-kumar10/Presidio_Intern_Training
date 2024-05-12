using RequestTrackerCFModals; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface IRequestBL
    {
        public Task<Request> GetRequest(int id);
        public Task<Request> AddRequest(Request request);
        public Task<Request> RemoveRequest(int id);
        public Task<IList<Request>> GetAllRequests();
        public Task<Request> UpdateRequest(Request request);
    }
}
