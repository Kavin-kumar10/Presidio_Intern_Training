using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    public class MaximumQuantityExceedException : Exception
    {
        string message;
        public MaximumQuantityExceedException()
        {
            message = "Item With Given Credentials is not found.";
        }
        public override string Message => message;
    }
}
