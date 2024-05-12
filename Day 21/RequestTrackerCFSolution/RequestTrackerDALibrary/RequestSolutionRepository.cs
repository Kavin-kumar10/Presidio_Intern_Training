using Microsoft.EntityFrameworkCore;
using RequestTrackerCFModals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALibrary
{
    public class RequestSolutionRepository : IRepository<int,RequestSolution>
    {
        private readonly RequestTrackerContext _context;

        public RequestSolutionRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<RequestSolution> Add(RequestSolution entity)
        {
            _context.RequestSolutions.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<RequestSolution> Delete(int key)
        {
            var requestsolution = await Get(key);
            if (requestsolution != null)
            {
                _context.RequestSolutions.Remove(requestsolution);
                await _context.SaveChangesAsync();
            }
            return requestsolution;
        }

        public async Task<RequestSolution> Get(int key)
        {
            var RequestSolution = _context.RequestSolutions.SingleOrDefault(rs => rs.RequestId == key);
            return RequestSolution;
        }

        public async Task<IList<RequestSolution>> GetAll()
        {
            return await _context.RequestSolutions.ToListAsync();
        }

        public async Task<RequestSolution> Update(RequestSolution entity)
        {
            var requestsolution = await Get(entity.RequestId);
            if (requestsolution != null)
            {
                _context.Entry<RequestSolution>(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return entity;
        }
    }
}
