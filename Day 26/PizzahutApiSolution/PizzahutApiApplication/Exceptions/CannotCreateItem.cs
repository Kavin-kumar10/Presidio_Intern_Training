using System.Runtime.Serialization;

namespace PizzahutApiApplication.Exceptions
{
    [Serializable]
    internal class CannotCreateItem : Exception
    {
        string message;
        public CannotCreateItem()
        {
            message = "Unable to Create Item";
        }
        public override string Message => message;
    }
}