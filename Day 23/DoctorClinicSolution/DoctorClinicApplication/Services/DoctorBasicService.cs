using DoctorClinicApplication.Exceptions;
using DoctorClinicApplication.Interface;
using DoctorClinicApplication.Modals;
using DoctorClinicApplication.Repositories;

namespace DoctorClinicApplication.Services
{
    public class DoctorBasicService : IDoctorService
    {
        private IRepository<int,Doctor> _repository;

        public DoctorBasicService(IRepository<int,Doctor> repository) { 
            _repository = repository;
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctors()
        {
            var result = await _repository.Get();
            return result.ToList();
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Doctor>> GetDoctorBySpeciality(string speciality)
        {
            var allDoctors = await _repository.Get();
            var result = allDoctors.Where(d=>d.Speciality == speciality).ToList();
            return result;
            throw new NotImplementedException();
        }

        public async Task<Doctor> UpdateDoctorExperience(int Id,int experience)
        {
            var doctor = await _repository.Get(Id);  
            if(doctor == null)
            {
                throw new NoSuchDoctorFound();
            }
            doctor.Experience = experience;
            await _repository.Update(doctor);
            return doctor;
        }
    }
}
