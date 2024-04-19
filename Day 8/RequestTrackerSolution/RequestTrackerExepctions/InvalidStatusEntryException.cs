using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerExepctions
{
    public class InvalidStatusEntryException : Exception
    {
        string msg;
        public InvalidStatusEntryException()
        {
            msg = "The Status value is Invalid. Please provide with valid Status";
        }

        public override string Message => msg;
    }
}
