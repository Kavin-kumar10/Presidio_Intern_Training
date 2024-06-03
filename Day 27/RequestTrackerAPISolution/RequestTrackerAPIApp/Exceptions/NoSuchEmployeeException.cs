using System.Runtime.Serialization;

namespace RequestTrackerAPIApp.Exceptions
{
    [Serializable]
    internal class NoSuchEmployeeException : Exception
    {
        string message;
        public NoSuchEmployeeException()
        {
            message = "No Employee with the ID present";
        }
        public override string Message => message;
    }
}