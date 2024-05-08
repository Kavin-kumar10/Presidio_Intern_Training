using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorTrackerException
{
    public class NoItemsFoundException : Exception
    {
        string msg;
        public NoItemsFoundException()
        {
            msg = "No Items Found";
        }

        public override string Message => msg;
    }
}
