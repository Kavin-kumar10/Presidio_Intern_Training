using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorhandlingExceptions
{
    public class DuplicateCustomerException : Exception
    {
        string msg;
        public DuplicateCustomerException()
        {
            msg = "The Customer With current Credentials already found";
        }
        public override string Message => msg;
    }
}
