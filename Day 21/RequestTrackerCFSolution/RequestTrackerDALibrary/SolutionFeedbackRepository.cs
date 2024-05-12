using Microsoft.EntityFrameworkCore;
using RequestTrackerCFModals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALibrary
{
    public class SolutionFeedbackRepository : IRepository<int, SolutionFeedback>
    {
        private readonly RequestTrackerContext _context;

        public SolutionFeedbackRepository(RequestTrackerContext context)
        {
            _context = context;
        }

        public async Task<SolutionFeedback> Add(SolutionFeedback entity)
        {
            _context.Feedbacks.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
            throw new NotImplementedException();
        }

        public async Task<SolutionFeedback> Delete(int key)
        {
            var solutionfeedback = await Get(key);
            if (solutionfeedback != null)
            {
                _context.Feedbacks.Remove(solutionfeedback);
                await _context.SaveChangesAsync();
            }
            return solutionfeedback;
            throw new NotImplementedException();
        }

        public async Task<SolutionFeedback> Get(int key)
        {
            var feedback = _context.Feedbacks.SingleOrDefault(f => f.FeedbackId == key);
            return feedback;
            throw new NotImplementedException();
        }

        public async Task<IList<SolutionFeedback>> GetAll()
        {
            return await _context.Feedbacks.ToListAsync();
            throw new NotImplementedException();
        }

        public async Task<SolutionFeedback> Update(SolutionFeedback entity)
        {
            var feedback =await Get(entity.FeedbackId);
            if (feedback!=null)
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();
            }
            throw new NotImplementedException();
        }
    }
}
