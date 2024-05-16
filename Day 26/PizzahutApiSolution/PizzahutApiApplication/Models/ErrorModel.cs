namespace PizzahutApiApplication.Models
{
    public class ErrorModel
    {
        public string ErrorMesage { get; set; }
        public int ErrorCode { get; set; }

        public ErrorModel(int errorcode,string errormessage)
        {
            ErrorMesage = errormessage;
            ErrorCode = errorcode;
        }
    }
}
