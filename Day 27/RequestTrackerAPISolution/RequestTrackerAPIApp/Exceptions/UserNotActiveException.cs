using System.Runtime.Serialization;

namespace RequestTrackerAPIApp.Exceptions
{
    [Serializable]
    internal class UserNotActiveException : Exception
    {
        string message;
        public UserNotActiveException()
        {
            message = "User is Not Active";
        }

        public UserNotActiveException(string errormessage)
        {
            message = errormessage;
        }

        public override string Message => message;
    }
}