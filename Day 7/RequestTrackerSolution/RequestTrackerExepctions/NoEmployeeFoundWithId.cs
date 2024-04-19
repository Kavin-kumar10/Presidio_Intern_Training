using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class NoEmployeeFoundWithId : Exception
    {
        string msg;
        public NoEmployeeFoundWithId() {
            msg = "The Employee with provided Employee ID is not found";
        }
        public override string Message => msg;
    }
}
