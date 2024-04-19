using RequestTrackerModalClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface IRequestService
    {
        int AddRequest(Request request);
        Request UpdateRequestText(string OldText, string NewText);
        int DeleteRequest(int Id);
        Request GetRequestById(int Id);
        List<Request> GetAllRequest();
    }
}
