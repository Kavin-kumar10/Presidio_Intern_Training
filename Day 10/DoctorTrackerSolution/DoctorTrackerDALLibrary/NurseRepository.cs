using DoctorTrackerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorTrackerDALLibrary
{
    public class NurseRepository : IRepository<int, Nurse>
    {
        readonly Dictionary<int,Nurse> _nurse;   
        public NurseRepository() {
            _nurse = new Dictionary<int,Nurse>();
        }

        public int GenerateId()
        {
            if (_nurse.Count == 0) return 0;
            int keys = _nurse.Keys.Max();
            return keys+1;
        }
        public Nurse Add(Nurse item)
        {
            if(_nurse.ContainsKey(item.Id))
            {
                return null;
            }
            _nurse.Add(item.Id, item);
            return item;
            throw new NotImplementedException();
        }

        public Nurse Delete(int Key)
        {
            if (_nurse.ContainsKey(Key)) {
                var nurse = _nurse[Key];
                _nurse.Remove(Key);
                return nurse;
            }
            return null;
            throw new NotImplementedException();
        }

        public Nurse Get(int Key)
        {
            if (_nurse.ContainsKey(Key)) return _nurse[Key];
            return null;
            throw new NotImplementedException();
        }

        public List<Nurse> GetAll()
        {
            return _nurse.Values.ToList();
            throw new NotImplementedException();
        }

        public Nurse Update(Nurse item)
        {
            if (_nurse.ContainsKey(item.Id))
            {
                _nurse[item.Id] = item;
            }
            return item;
            throw new NotImplementedException();
        }
    }
}
