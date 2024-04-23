using DoctorTrackerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorTrackerDALLibrary
{
    public class AppointmentRepository : IRepository<int,Appointment>
    {
        readonly Dictionary<int, Appointment> _appointment;
        public AppointmentRepository()
        {
            _appointment = new Dictionary<int, Appointment>();
        }

        public int GenerateId()
        {
            if (_appointment.Count == 0) return 0;
            int id = _appointment.Keys.Max();
            return ++id;
        }

        public Appointment Add(Appointment item)
        {
            if (_appointment.ContainsKey(item.Id))
            {
                return null;
            }
            _appointment.Add(GenerateId(), item);
            return item;
        }

        public Appointment Delete(int Key)
        {
            if (_appointment.ContainsKey(Key))
            {
                var appointment = _appointment[Key];
                _appointment.Remove(Key);
                return appointment;
            }
            return null;
        }

        public Appointment Get(int Key)
        {
            if (_appointment.ContainsKey(Key)) { return _appointment[Key]; }
            return null;
        }

        public List<Appointment> GetAll()
        {
            if (_appointment.Count == 0) return null;
            return _appointment.Values.ToList();
        }

        public Appointment Update(Appointment item)
        {
            if (_appointment.ContainsKey(item.Id))
            {
                _appointment[item.Id] = item;
                return item;
            }
            return null;
        }
    }
}
