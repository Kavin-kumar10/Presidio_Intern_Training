using System.Runtime.Serialization;

namespace RequestTrackerAPIApp.Exceptions
{
    [Serializable]
    internal class UnableToRegisterException : Exception
    {
        string message;
        public UnableToRegisterException()
        {
            message = "Unable to Register";
        }
        public UnableToRegisterException(string? message)
        {
            this.message = message;
        }

        public override string Message => message;
    }
}