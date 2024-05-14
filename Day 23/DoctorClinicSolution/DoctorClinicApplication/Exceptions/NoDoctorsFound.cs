namespace DoctorClinicApplication.Exceptions
{
    public class NoDoctorsFound : Exception
    {
        string message;
        public NoDoctorsFound() {
            message = "No Doctors found";
        }
        public override string Message => message;
    }
}
