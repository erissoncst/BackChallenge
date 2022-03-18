using Domain.Constants;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class UserResponse
    {
        public String JwtToken { get; set; }
        public String Login { get; set; }
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }

        public static UserResponse Of(String jwtToken, User user)
        {
            return new UserResponse { JwtToken = jwtToken, Customer = user.Customer, Employee = user.Employee };
        }
    }
}
