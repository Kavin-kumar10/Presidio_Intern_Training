using RequestTrackerModalClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class RequestRepository : IRepository<int, Request>
    {
        readonly Dictionary<int, Request> _request;
        public RequestRepository()
        {
            _request = new Dictionary<int, Request>();
        }
        int GenerateId()
        {
            if (_request.Count == 0)
                return 1;
            int id = _request.Keys.Max();
            return ++id;
        }
        public Request Add(Request item)
        {
            if (_request.ContainsValue(item))
            {
                return null;
            }
            _request.Add(GenerateId(), item);
            return item;
        }

        public Request Delete(int key)
        {
            if (_request.ContainsKey(key))
            {
                var employee = _request[key];
                _request.Remove(key);
                return employee;
            }
            return null;
        }

        public Request Get(int key)
        {
            return _request.ContainsKey(key) ? _request[key] : null;
        }

        public List<Request> GetAll()
        {
            if (_request.Count == 0)
                return null;
            return _request.Values.ToList();
        }

        public Request Update(Request  item)
        {
            if (_request.ContainsKey(item.Id))
            {
                _request[item.Id] = item;
                return item;
            }
            return null;
        }

    }
}
