using DoctorClinicApplication.Modals;

namespace DoctorClinicApplication.Interface
{
    public interface IDoctorService
    {
        public Task<IEnumerable<Doctor>> GetAllDoctors();
        public Task<Doctor> UpdateDoctorExperience(int Id, int experience);
        public Task<IEnumerable<Doctor>> GetDoctorBySpeciality(string speciality);

    }
}
