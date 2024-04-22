using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorhandlingExceptions
{
    public class CannotFindTheObjectException : Exception
    {
        string msg;
        public CannotFindTheObjectException()
        {
            msg = "Cannot Find the Object with the given Id";
        }

        public override string Message => msg;
    }
}
