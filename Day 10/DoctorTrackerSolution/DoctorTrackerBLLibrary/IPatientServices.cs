using DoctorTrackerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorTrackerBLLibrary
{
    public interface IPatientServices
    {
        List<Patient> GetAllPatients();
        Patient GetPatientByID(int Id);
        int AddPatient(Patient patient);
        Patient UpdatePatient(Patient patient);
        Patient DeletePatient(int Id);
        Patient GetPatientByName(string Name);
    }
}
