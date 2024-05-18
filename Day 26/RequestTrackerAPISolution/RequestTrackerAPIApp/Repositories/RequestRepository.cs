using Microsoft.EntityFrameworkCore;
using RequestTrackerAPIApp.Context;
using RequestTrackerAPIApp.Interfaces;
using RequestTrackerAPIApp.Modals;

namespace RequestTrackerAPIApp.Repositories
{
    public class RequestRepository : IRepository<int, Request>
    {
        private readonly RequestTrackerContext _context;

        public RequestRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<Request> Add(Request entity)
        {
            _context.Requests.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Request> Delete(int key)
        {
            var request = await Get(key);
            if (request != null)
            {
                _context.Requests.Remove(request);
                await _context.SaveChangesAsync();
            }
            return request;
        }

        public async Task<IEnumerable<Request>> Get()
        {
            var result = _context.Requests.ToList();
            return result;
        }

        public async Task<Request> Get(int key)
        {
            var Request = _context.Requests.SingleOrDefault(r => r.RequestNumber == key);
            return Request;
        }


        public async Task<Request> Update(Request entity)
        {
            var request = await Get(entity.RequestNumber);
            if (request != null)
            {
                _context.Entry<Request>(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return entity;
        }

    }
}
