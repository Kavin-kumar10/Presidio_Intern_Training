using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerModule
{
    public interface IClientInteraction
    {
        void GetOrder();
        void GetPayment();
    }
}
