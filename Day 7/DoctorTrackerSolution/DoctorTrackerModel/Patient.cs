using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorTrackerModel
{
    public class Patient
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string DiseaseName { get; set; }
        public int DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }

        public Patient() { 
            Id = 0;
            Name = string.Empty;
            DiseaseName = string.Empty;
            DateOfBirth = 0;
            Age = 0;
            Address = string.Empty;
            MobileNumber = string.Empty;
        }

        public Patient(int id) { Id = id; }

        public Patient(int id, string name, string diseaseName, int dateOfBirth, int age, string address, string mobileNumber)
        {
            Id = id;
            Name = name;
            DiseaseName = diseaseName;
            DateOfBirth = dateOfBirth;
            Age = age;
            Address = address;
            MobileNumber = mobileNumber;
        }


    }
}
