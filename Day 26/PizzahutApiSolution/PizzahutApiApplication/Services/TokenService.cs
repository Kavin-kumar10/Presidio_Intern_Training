using Microsoft.IdentityModel.Tokens;
using PizzahutApiApplication.Interfaces;
using PizzahutApiApplication.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PizzahutApiApplication.Services
{
    public class TokenService : ITokenService
    {
        // jwt - header, payload, signature

        private readonly string _secretKey;
        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration configuration)
        {
            _secretKey = configuration.GetSection("TokenKey").GetSection("JWT").Value.ToString();
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
        }

        public string GenerateToken(Customer customer)
        {
            string token = string.Empty;

            //Payload
            var claims = new List<Claim>(){
                new Claim(ClaimTypes.Name,customer.Id.ToString())
            };

            //Header with algorithm and signature
            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

            //Token assembly
            var myToken = new JwtSecurityToken(null, null, claims, expires: DateTime.Now.AddDays(1), signingCredentials: credentials);

            //Token Handling
            token = new JwtSecurityTokenHandler().WriteToken(myToken);
            return token;

        }
    }
}
