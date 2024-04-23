using DoctorTrackerModel;

namespace DoctorTrackerDALLibrary
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        readonly Dictionary<int, Doctor> _doctors;
        public DoctorRepository() { 
            _doctors = new Dictionary<int, Doctor>();
        }

        public int GenerateId()
        {
            if (_doctors.Count == 0) return 1;
            int id = _doctors.Keys.Max();
            return ++id;
        }

        public Doctor Add(Doctor item)
        {
            if(_doctors.ContainsKey(item.Id)) {
                return null;
            }
            item.Id = GenerateId();
            _doctors.Add(item.Id, item);
            return item;
        }

        public Doctor Delete(int Key)
        {
            if(_doctors.ContainsKey(Key)) {
                var doctor = _doctors[Key];
                _doctors.Remove(Key);
                return doctor;
            }
            return null;
        }

        public Doctor Get(int Key)
        {
            if(_doctors.ContainsKey(Key)) { return _doctors[Key]; }
            return null;
        }

        public List<Doctor> GetAll()
        {
            if (_doctors.Count == 0) return null;
            return _doctors.Values.ToList();
        }

        public Doctor Update(Doctor item)
        {
            if (_doctors.ContainsKey(item.Id))
            {
                _doctors[item.Id] = item;
                return item;
            }
            return null;
        }
    }
}
