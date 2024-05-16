using System.Runtime.Serialization;

namespace RequestTrackerAPIApp.Exceptions
{
    [Serializable]
    internal class UnauthorizedUserException : Exception
    {
        string message;
        public UnauthorizedUserException()
        {
            message = "Unauthorized User";
        }

        public UnauthorizedUserException(string errormessage)
        {
            message = errormessage;
        }

        public override string Message => message;
    }
}