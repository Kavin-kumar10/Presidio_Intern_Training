using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class DuplicateEmployeeDetailsException : Exception
    {
        string msg;
        public DuplicateEmployeeDetailsException() {
            msg = "The Employee Already found";
        }

        public override string Message => msg;
    }
}
