using System.Runtime.Serialization;

namespace RequestTrackerAPIApp.Exceptions
{
    [Serializable]
    internal class NoRequestFound : Exception
    {
        string message;
        public NoRequestFound()
        {
            message = "No Request Found";
        }
        public override string Message => message;
    }
}