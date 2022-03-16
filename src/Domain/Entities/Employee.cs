using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("employees")]
    public class Employee
    {

        [Key]
        [Column("employee_id")]
        public Int64 EmployeeId { get; set; }

        [Column("full_name")]
        public String FullName { get; set; }

        [Column("registration")]
        public String Registration { get; set; }

        [Column("user_id")]
        public Int64 UserId { get; set; }

        public User User { get; set; }

    }
}
