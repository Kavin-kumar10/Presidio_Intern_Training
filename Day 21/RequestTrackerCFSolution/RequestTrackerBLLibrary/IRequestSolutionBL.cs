using RequestTrackerCFModals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface IRequestSolutionBL
    {
        public Task<RequestSolution> GetRequestSolution(int id);
        public Task<RequestSolution> AddRequestSolution(RequestSolution requestsolution);
        public Task<RequestSolution> RemoveRequestSolution(int id);
        public Task<IList<RequestSolution>> GetAllRequestSolutionbyId(int RequestID);
        public Task<IList<RequestSolution>> GetAllRequestSolution();
        public Task<RequestSolution> UpdateRequestSolution(RequestSolution requestsolution);
    }
}
