using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorTrackerModel
{
    public class Appointment : IEquatable<Appointment>
    {
        public int Id { get; set; }
        public string DiseaseName { get; set; }
        public int PatientId { get; set; }
        public string Status { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; } = DateTime.Now;

        public bool Equals(Appointment? other)
        {
            return Id.Equals(other.Id);
        }
        //public bool Equals(Request? other) => Id.Equals(other.Id);


        public Appointment()
        {
            Appointment appointment = new Appointment();
        }

        public Appointment(int id)
        {
            Id = id;
        }

        public Appointment(int id, string diseaseName, int patientId, string status, int doctorId, DateTime appointmentDate)
        {
            Id = id;
            DiseaseName = diseaseName;
            PatientId = patientId;
            Status = status;
            DoctorId = doctorId;
            AppointmentDate = appointmentDate;
        }


    }

}
