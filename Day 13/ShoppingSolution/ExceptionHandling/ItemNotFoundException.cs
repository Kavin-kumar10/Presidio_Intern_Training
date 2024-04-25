using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    public class ItemNotFoundException : Exception
    {
        string message;
        public ItemNotFoundException()
        {
            message = "Item With Given Credentials is not found.";
        }
        public override string Message => message;
    }
}
