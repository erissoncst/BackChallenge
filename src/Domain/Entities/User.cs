using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public Customer? Customer { get; set; }

        public Employee? Employee { get; set; }

        public static User Of(string login, string password)
        {
            return new User { Login= login, Password=password};
        }
    }
}
