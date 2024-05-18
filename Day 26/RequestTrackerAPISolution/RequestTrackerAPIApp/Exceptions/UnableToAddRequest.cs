using System.Runtime.Serialization;

namespace RequestTrackerAPIApp.Exceptions
{
    [Serializable]
    internal class UnableToAddRequest : Exception
    {
        string message;
        public UnableToAddRequest()
        {
            message = "Unable to add the request";
        }
        public override string Message => message;

    }
}