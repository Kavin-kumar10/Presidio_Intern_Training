using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerExepctions
{
    public class RequestNotFoundException : Exception
    {
        string msg;
        public RequestNotFoundException()
        {
            msg = "The Request Id Not found.  Please check for the Id.";
        }

        public override string Message => msg;
    }
}
