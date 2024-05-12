using RequestTrackerCFModals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface ISolutionFeedback
    {
        public Task<SolutionFeedback> GetFeedback(int id);
        public Task<SolutionFeedback> AddFeedback(SolutionFeedback solutionfeedback);
        public Task<SolutionFeedback> RemoveFeedback(int id);
        public Task<IList<SolutionFeedback>> GetAllfeedback();
        public Task<IList<SolutionFeedback>> GetAllfeedbackBySolutionID(int SolutionID);

        public Task<SolutionFeedback> UpdateRequest(SolutionFeedback solutionfeedback);
    }
}
