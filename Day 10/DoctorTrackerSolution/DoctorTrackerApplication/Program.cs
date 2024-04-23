using DoctorTrackerModel;

namespace DoctorTrackerApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Doctor doctor = new Doctor(1,"kavin",3,29,"MBBS.,","Cardio");
            Console.WriteLine(doctor.ToString());
            
        }
    }
}
