using DoctorClinicApplication.Modals;
using Microsoft.EntityFrameworkCore;

namespace DoctorClinicApplication.Context
{
    public class DoctorClinicContext : DbContext
    {
        public DoctorClinicContext(DbContextOptions options):base(options) {
            
        }
        public DbSet<Doctor> Doctors {  get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor() { Id = 101,Name = "Kavin",Age = 25,Experience = 12,Qualification = "MBBS.,",Speciality = "Cardio"},
                new Doctor() { Id = 102, Name = "Pravin", Age = 35, Experience = 15, Qualification = "MBBS.,", Speciality = "Ortho" },
                new Doctor() { Id = 103, Name = "Raja", Age = 45, Experience = 22, Qualification = "MBBS.,M.sc.,", Speciality = "Cardio" }
            );
        }
    }
}
