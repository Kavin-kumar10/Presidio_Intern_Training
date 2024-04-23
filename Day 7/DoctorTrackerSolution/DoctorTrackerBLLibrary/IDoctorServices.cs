using DoctorTrackerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorTrackerBLLibrary
{
    public interface IDoctorServices
    {
        List<Doctor> GetAllDoctors();
        Doctor GetDoctorByID(int Id);
        int AddDoctor(Doctor doctor);
        Doctor UpdateDoctor(Doctor doctor);
        Doctor DeleteDoctor(int Id);
        Doctor GetDoctorByName(string Name);
    }
}
