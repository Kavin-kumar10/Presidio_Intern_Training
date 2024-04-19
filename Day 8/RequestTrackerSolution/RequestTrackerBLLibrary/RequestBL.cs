using RequestTrackerDALLibrary;
using RequestTrackerExepctions;
using RequestTrackerModalClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class RequestBL
    {
        IRepository<int, Request> _requestrepository;

        public RequestBL()
        {
            _requestrepository = new RequestRepository();
        }
        public int AddRequest(Request request)
        {
            var result = _requestrepository.Add(request);
            if (result != null)
                return request.Id;
            throw new DuplicateDepartmentNameException();
        }

        public int DeleteRequest(int Id)
        {
            var result = _requestrepository.Delete(Id);
            if (result != null) return Id;
            throw new NoEmployeeFoundWithId();
        }

        public List<Request> GetAllRequest()
        {
            var result = _requestrepository.GetAll();
            if (result != null) return result;
            throw new NotImplementedException();
        }

        public Request GetEmployeeById(int Id)
        {
            var result = _requestrepository.Get(Id);
            if (result != null) return result;
            throw new NoEmployeeFoundWithId();
        }

        public Request UpdateRequestText(string OldText, string NewText)
        {
            List<Request> AllRequest = _requestrepository.GetAll();
            if (AllRequest != null)
            {
                for (int i = 0; i < AllRequest.Count; i++)
                {
                    if (AllRequest[i].RequestText == OldText)
                    {
                        AllRequest[i].RequestText = NewText;
                        return AllRequest[i];
                    }
                }
            }
            throw new NotImplementedException();
        }

        public Request UpdateRequestStatus(int Id,int status)
        {
            List<Request> requests = _requestrepository.GetAll();
            if (requests != null)
            {
                for(int ind = 0; ind < requests.Count; ind++)
                {
                    if (requests[ind].Id == Id)
                    {
                        if (status == 0)
                        {
                            requests[ind].Status = "Pending";
                        }
                        else if (status == 1) requests[ind].Status = "Accepted";
                        else if (status == 2) requests[ind].Status = "Rejected";
                        else
                            throw new InvalidStatusEntryException();
                    }
                }
            }
            throw new RequestNotFoundException();
        }
    }
}
