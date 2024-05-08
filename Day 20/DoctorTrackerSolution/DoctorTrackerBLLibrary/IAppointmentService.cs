using DoctorTrackerDALLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorTrackerBLLibrary
{
    public interface IAppointmentService
    {
        List<Appointment> GetAllAppointment();
        Appointment GetAppointmentByID(int Id);
        int AddAppointment(Appointment appointment);
        Appointment UpdateAppointment(Appointment appointment);
        Appointment DeleteAppointment(int Id);
        Appointment GetAppointmentByAppointmentIdAndPatientId(int DoctorId, int PatientId);

    }
}
