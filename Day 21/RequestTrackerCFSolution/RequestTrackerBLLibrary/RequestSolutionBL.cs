using RequestTrackerCFModals;
using RequestTrackerDALibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class RequestSolutionBL : IRequestSolutionBL
    {
        private readonly IRepository<int, RequestSolution> _repository;
        public RequestSolutionBL()
        {
            _repository = new RequestSolutionRepository(new RequestTrackerContext());
        }

        public async Task<RequestSolution> AddRequestSolution(RequestSolution requestsolution)
        {
            var result =await _repository.Add(requestsolution);
            if (result != null) { return result; }
            throw new NotImplementedException();
        }

        public async Task<IList<RequestSolution>> GetAllRequestSolutionbyId(int RequestID)
        {
            var allSolutions =await _repository.GetAll();
            var result = allSolutions.Where(s=>s.RequestId == RequestID).ToList();
            return result;
            throw new NotImplementedException();
        }

        public async Task<IList<RequestSolution>> GetAllRequestSolution()
        {
            var result = await _repository.GetAll();
            return result.ToList();
            throw new NotImplementedException();
        }

        public async Task<RequestSolution> GetRequestSolution(int id)
        {
            return await _repository.Get(id);
            throw new NotImplementedException();
        }

        public Task<RequestSolution> RemoveRequestSolution(int id)
        {
            var result = _repository.Delete(id);
            return result;
            throw new NotImplementedException();
        }

        public Task<RequestSolution> UpdateRequestSolution(RequestSolution requestsolution)
        {
            var result = _repository.Update(requestsolution);
            return result;
            throw new NotImplementedException();
        }
    }
}
