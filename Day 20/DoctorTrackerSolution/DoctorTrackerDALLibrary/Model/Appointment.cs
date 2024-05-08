using System;
using System.Collections.Generic;

namespace DoctorTrackerDALLibrary.Model
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public string DiseaseName { get; set; } = null!;
        public int? PatientId { get; set; }
        public string? Status { get; set; }
        public int? DoctorId { get; set; }
        public DateTime? AppointmentDate { get; set; }
    }
}
