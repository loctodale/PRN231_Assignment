using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KoiTravelShop.KoiOrderService.Infrastructure
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public sealed class TokenProvider(IConfiguration configuration)
    {
        //public string Create(User user)
        //{
        //    string secretKey = configuration["Jwt:Secret"]!;
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    var tokenDesciptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(
        //            [
        //                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
        //                new Claim(JwtRegisteredClaimNames.Email, user.Email),
        //                new Claim("Fullname", user.Name)
        //            ]),
        //        Expires = DateTime.UtcNow.AddMinutes(60)
        //    };
        //}



    }
}
