using DoctorTrackerBLLibrary;
using DoctorTrackerDALLibrary;
using DoctorTrackerDALLibrary.Model;

namespace DoctorTrackerApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Doctor doctor = new Doctor();
            doctor.Id = 102;
            doctor.Name = "kavin";
            doctor.Age = 10;
            doctor.Qualification = "MBBS";
            doctor.Speciality = "Cardio";
            doctor.Experience = 20;
            Console.WriteLine(doctor.ToString());
            IDoctorServices doctorBL = new DoctorBL(new DoctorRepository());
            doctorBL.AddDoctor(doctor);
            
        }
    }
}
