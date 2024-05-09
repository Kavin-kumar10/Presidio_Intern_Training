using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryMigrationConflict
{
    public class Request
    {
        public int Id { get; set; }
        public string RequestMessage { get; set; }
        public string ResponseMessage { get; set; }
        public string RequestType { get; set; }
        public string ResponseType { get; set; }
        public int Rating { get; set; }
    }
}


// 1. init
// 2. mig-sal
// 3. mig-reqType
// 4. mig-mem

//moved to mig-sal
// 5. mig-resType