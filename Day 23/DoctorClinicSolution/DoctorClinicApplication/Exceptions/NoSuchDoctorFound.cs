using System.Runtime.Serialization;

namespace DoctorClinicApplication.Exceptions
{
    [Serializable]
    public class NoSuchDoctorFound : Exception
    {
        string message;
        public NoSuchDoctorFound()
        {
            message = "No Such Doctor Found";
        }
        public override string Message => message;

    }
}