using DoctorTrackerDALLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorTrackerDALLibrary
{
    public class PatientRepository : IRepository<int, Patient>
    {
        readonly Dictionary<int, Patient> _Patient;
        public PatientRepository()
        {
            _Patient = new Dictionary<int, Patient>();
        }

        public int GenerateId()
        {
            if (_Patient.Count == 0) return 0;
            int id = _Patient.Keys.Max();
            return ++id;
        }

        public Patient Add(Patient item)
        {
            if (_Patient.ContainsKey(item.Id))
            {
                return null;
            }
            item.Id = GenerateId();
            _Patient.Add(item.Id, item);
            return item;
        }

        public Patient Delete(int Key)
        {
            if (_Patient.ContainsKey(Key))
            {
                var patient = _Patient[Key];
                _Patient.Remove(Key);
                return patient;
            }
            return null;
        }

        public Patient Get(int Key)
        {
            if (_Patient.ContainsKey(Key)) { return _Patient[Key]; }
            return null;
        }

        public List<Patient>GetAll()
        {
            if (_Patient.Count == 0) return null;
            return _Patient.Values.ToList();
        }

        public Patient Update(Patient item)
        {
            if (_Patient.ContainsKey(item.Id))
            {
                _Patient[item.Id] = item;
                return item;
            }
            return null;
        }
    }
}
