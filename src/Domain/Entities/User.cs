using Domain.Constants;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Domain.Entities
{
    [Table("users")]
    public class User
    {

        [Key]
        [Column("user_id")]
        public Int64 UserId { get; set; }

        [Column("login")]
        public String Login { get; set; }

        [Column("password")]
        public String Password { get; set; }

        public Customer Customer { get; set; }

        public Employee Employee { get; set; }

        public static string CUSTOMER = "CUSTOMER";
        public static string EMPLOYEE = "EMPLOYEE";

        public static User Of(string login, string password)
        {
            return new User { Login= login, Password=password};
        }

        public static String EncodingPassword(String Password)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
             password: Password,
             salt: Encoding.ASCII.GetBytes(Settings.Secret),
             prf: KeyDerivationPrf.HMACSHA256,
             iterationCount: 100000,
             numBytesRequested: 256 / 8));

        }

        public static string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            var roles = new List<Claim>();

            if(user.Customer != null)
            {
                roles.Add(new Claim(ClaimTypes.Role, CUSTOMER));
            }

            if (user.Employee != null)
            {
                roles.Add(new Claim(ClaimTypes.Role, EMPLOYEE));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(roles),
                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
