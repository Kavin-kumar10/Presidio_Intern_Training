using DoctorTrackerDALLibrary;
using DoctorTrackerModel;
using DoctorTrackerException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorTrackerBLLibrary
{
    public class DoctorBL : IDoctorServices
    {
        readonly IRepository<int, Doctor> _doctorRepository;

        public DoctorBL(IRepository<int,Doctor> doctorrepository)
        {
            _doctorRepository = doctorrepository;
        }
        public int AddDoctor(Doctor doctor)
        {
            if (_doctorRepository.Add(doctor) != null)
                return doctor.Id;
            throw new DuplicateItemException();
        }

        public Doctor DeleteDoctor(int Id)
        {
            var result = _doctorRepository.Delete(Id);
            if(result != null)return result;
            throw new ItemNotFoundException();
        }

        public List<Doctor> GetAllDoctors()
        {
            var result = _doctorRepository.GetAll();
            if (result != null) return result;
            throw new NoItemsFoundException();
        }

        public Doctor GetDoctorByID(int Id)
        {
            var result = _doctorRepository.Get(Id);
            if(result != null) return result;   
            throw new ItemNotFoundException();
        }

        public Doctor GetDoctorByName(string Name)
        {
            List<Doctor> doctors = _doctorRepository.GetAll();
            foreach(Doctor doctor in doctors)
                if(doctor.Name == Name) return doctor;
            throw new ItemNotFoundException();
        }

        public Doctor UpdateDoctor(Doctor doctor)
        {
            var result = _doctorRepository.Update(doctor);
            if(result != null) return result;   
            throw new ItemNotFoundException();
        }
    }
}
