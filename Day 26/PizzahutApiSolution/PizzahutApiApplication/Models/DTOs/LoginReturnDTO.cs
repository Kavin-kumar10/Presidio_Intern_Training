namespace PizzahutApiApplication.Models.DTOs
{
    public class LoginReturnDTO
    {
        public int CustomerId { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
    }
}
