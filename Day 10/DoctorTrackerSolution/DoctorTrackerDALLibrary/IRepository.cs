using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorTrackerDALLibrary
{
    public interface IRepository<K,T> where T : class
    {
        List<T> GetAll();
        T Get(K Key);
        T Add(T item);
        T Update(T item);
        T Delete(K Key);
    }
}
