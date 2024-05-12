using RequestTrackerCFModals;
using RequestTrackerDALibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class SolutionFeedbackBL : ISolutionFeedback
    {
        IRepository<int,SolutionFeedback> _repository;
        public SolutionFeedbackBL() {
            _repository = new SolutionFeedbackRepository(new RequestTrackerContext());
        }

        public Task<SolutionFeedback> AddFeedback(SolutionFeedback solutionfeedback)
        {
            var result = _repository.Add(solutionfeedback);
            return result;
            throw new NotImplementedException();
        }

        public Task<IList<SolutionFeedback>> GetAllfeedback()
        {
            return _repository.GetAll();
            throw new NotImplementedException();
        }

        public async Task<IList<SolutionFeedback>> GetAllfeedbackBySolutionID(int SolutionID)
        {
            var allFeedbacks = await _repository.GetAll();
            var result = allFeedbacks.Where(f=>f.SolutionId == SolutionID).ToList();
            return result;
            throw new NotImplementedException();
        }

        public Task<SolutionFeedback> GetFeedback(int id)
        {
            return _repository.Get(id);
            throw new NotImplementedException();
        }

        public async Task<SolutionFeedback> RemoveFeedback(int id)
        {
            return await _repository.Delete(id);
            throw new NotImplementedException();
        }

        public async Task<SolutionFeedback> UpdateRequest(SolutionFeedback solutionfeedback)
        {
            return await _repository.Update(solutionfeedback);
            throw new NotImplementedException();
        }
    }
}
