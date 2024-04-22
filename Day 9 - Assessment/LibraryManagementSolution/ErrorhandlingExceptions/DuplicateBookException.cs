namespace ErrorhandlingExceptions
{
    public class DuplicateBookException : Exception
    {
        string msg;
        public DuplicateBookException() { 
            msg = "The Book With current Credentials already found";
        }
        public override string Message => msg;
    }
}
