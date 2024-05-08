using System;
using System.Collections.Generic;

namespace DoctorTrackerDALLibrary.Model
{
    public partial class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? DiseaseName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? Age { get; set; }
        public string? Address { get; set; }
        public string? MobileNumber { get; set; }
    }
}
