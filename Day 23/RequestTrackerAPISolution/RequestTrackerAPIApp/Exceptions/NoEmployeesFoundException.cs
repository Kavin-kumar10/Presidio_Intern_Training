using System.Runtime.Serialization;

namespace RequestTrackerAPIApp.Exceptions
{
    [Serializable]
    internal class NoEmployeesFoundException : Exception
    {
        string message;
        public NoEmployeesFoundException()
        {
            message = "No Employees Found";
        }
        public override string Message => message;
    }
}