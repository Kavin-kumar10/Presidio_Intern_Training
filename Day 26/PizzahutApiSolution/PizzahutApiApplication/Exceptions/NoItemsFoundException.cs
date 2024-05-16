using System.Runtime.Serialization;

namespace PizzahutApiApplication.Exceptions
{
    [Serializable]
    internal class NoItemsFoundException : Exception
    {
        string message;
        public NoItemsFoundException()
        {
            message = "No Items Found";
        }
        public override string Message => message;

    }
}