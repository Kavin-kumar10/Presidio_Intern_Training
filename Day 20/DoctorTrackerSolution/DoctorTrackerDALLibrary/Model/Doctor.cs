using System;
using System.Collections.Generic;

namespace DoctorTrackerDALLibrary.Model
{
    public partial class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Experience { get; set; }
        public int? Age { get; set; }
        public string? Qualification { get; set; }
        public string? Speciality { get; set; }
    }
}
