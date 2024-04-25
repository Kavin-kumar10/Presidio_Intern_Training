using DoctorTrackerDALLibrary;
using DoctorTrackerException;
using DoctorTrackerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorTrackerBLLibrary
{
    public class AppointmentBL : IAppointmentService
    {
        readonly IRepository<int, Appointment> _appointmentrepository;

        public AppointmentBL(IRepository<int, Appointment> appointmentrepository)
        {
            _appointmentrepository = appointmentrepository;
        }
        public int AddAppointment(Appointment appointment)
        {
            if (_appointmentrepository.Add(appointment) != null)
                return appointment.Id;
            throw new DuplicateItemException();
        }

        public Appointment DeleteAppointment(int Id)
        {
            var result = _appointmentrepository.Delete(Id);
            if (result != null) return result;
            throw new ItemNotFoundException();
        }

        public List<Appointment> GetAllAppointment()
        {
            var result = _appointmentrepository.GetAll();
            if (result != null) return result;
            throw new NoItemsFoundException();
        }

        public Appointment GetAppointmentByID(int Id)
        {
            var result = _appointmentrepository.Get(Id);
            if (result != null) return result;
            throw new ItemNotFoundException();
        }

        public Appointment UpdateAppointment(Appointment Appointment)
        {
            var result = _appointmentrepository.Update(Appointment);
            if (result != null) return result;
            throw new ItemNotFoundException();
        }
        public Appointment GetAppointmentByAppointmentIdAndPatientId(int DoctorId, int PatientId)
        {
            List<Appointment> AllAppointment = _appointmentrepository.GetAll();
            for (int i = 0; i < AllAppointment.Count; i++)
            {
                if (AllAppointment[i].PatientId == PatientId && AllAppointment[i].DoctorId == DoctorId)
                {
                    return AllAppointment[i];
                }
            }
            throw new ItemNotFoundException();
        }
    }
}
