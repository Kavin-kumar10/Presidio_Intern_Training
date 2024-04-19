using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerExepctions
{
    public class DuplicateRequestFoundExeption : Exception
    {
        string msg;
        public DuplicateRequestFoundExeption()
        {
            msg = "The Request is Already Found";
        }

        public override string Message => msg;
    }
}
