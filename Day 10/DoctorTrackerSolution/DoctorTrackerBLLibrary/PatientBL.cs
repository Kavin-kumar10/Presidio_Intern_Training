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
    public class PatientBL : IPatientServices
    {
        readonly IRepository<int, Patient> _patientrepository;

        public PatientBL(IRepository<int, Patient> patientrepository)
        {
            _patientrepository = patientrepository;
        }
        public int AddPatient(Patient patient)
        {
            if (_patientrepository.Add(patient) != null)
                return patient.Id;
            throw new DuplicateItemException();
        }

        public Patient DeletePatient(int Id)
        {
            var result = _patientrepository.Delete(Id);
            if (result != null) return result;
            throw new ItemNotFoundException();
        }

        public List<Patient> GetAllPatients()
        {
            var result = _patientrepository.GetAll();
            if (result != null) return result;
            throw new NoItemsFoundException();
        }

        public Patient GetPatientByID(int Id)
        {
            var result = _patientrepository.Get(Id);
            if (result != null) return result;
            throw new ItemNotFoundException();
        }

        public Patient GetPatientByName(string Name)
        {
            List<Patient> Patients = _patientrepository.GetAll();
            foreach (Patient Patient in Patients)
                if (Patient.Name == Name) return Patient;
            throw new ItemNotFoundException();
        }

        public Patient UpdatePatient(Patient Patient)
        {
            var result = _patientrepository.Update(Patient);
            if (result != null) return result;
            throw new ItemNotFoundException();
        }
    }
}
