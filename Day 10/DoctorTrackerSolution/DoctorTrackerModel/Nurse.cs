using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorTrackerModel
{
    public class Nurse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Doctor> Doctors { get; set; }
        public bool MariatalStatus { get; set; }
        public Nurse() { 
            Id = 0;
            Name = string.Empty;
            Doctors  = new List<Doctor>();
            MariatalStatus = true;
        }

        public Nurse(int id)
        {
            Id = id;
        }
        public Nurse(int id, string name, List<Doctor> doctors, bool mariatalStatus)
        {
            Id = id;
            Name = name;
            Doctors = doctors;
            MariatalStatus = mariatalStatus;
        }

    }
}
