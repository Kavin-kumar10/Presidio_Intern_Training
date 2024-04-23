namespace DoctorTrackerException
{
    public class DuplicateItemException : Exception
    {
        string msg;
        public DuplicateItemException()
        {
            msg = "The Item with current Credentials is Already Found";
        }

        public override string Message => msg;
    }
}
