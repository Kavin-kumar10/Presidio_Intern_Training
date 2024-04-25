using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    public class DuplicateItemFoundException :Exception
    {
        string message;
        public DuplicateItemFoundException()
        {
            message = "The Item with the given credentials already found";
        }
        public override string Message => message;
    }
}
