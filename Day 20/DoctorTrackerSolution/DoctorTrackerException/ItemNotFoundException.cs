using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorTrackerException
{
    public class ItemNotFoundException : Exception
    {
        string msg;
        public ItemNotFoundException() {
            msg = "The Item not found, Please provide with valid credentials.";
        }

        public override string Message => msg;
    }
}
