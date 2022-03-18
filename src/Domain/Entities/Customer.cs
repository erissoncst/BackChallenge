using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("customers")]
    public class Customer
    {

        [Key]
        [Column("customer_id")]
        public Int64 CustomerId { get; set; }

        [Column("full_name")]
        public String FullName { get; set; }

        [Column("individual_registration")]
        public String IndividualRegistration { get; set; }

        [Column("birth_date")]
        public DateOnly BirthDate { get; set; }

        [Column("zip_code")]
        public String ZipCode { get; set; }

        [Column("public_place")]
        public String PublicPlace { get; set; }

        [Column("number")]
        public String Number { get; set; }

        [Column("complement")]
        public String? Complement { get; set; }

        [Column("city")]
        public String City { get; set; }

        [Column("state")]
        public String State { get; set; }

        [Column("user_id")]
        public Int64 UserId { get; set; }

        public User User { get; set; }

        public static Customer Of(String fullName, 
            String individualRegistration, 
            DateOnly birthDate, 
            string zipCode, 
            String publicPlace,
            String number,
            String complement,
            String city,
            String state,
            User user)
        {
            return new Customer
            {
                FullName = fullName,
                IndividualRegistration = individualRegistration,
                BirthDate = birthDate,
                ZipCode = zipCode,
                PublicPlace = publicPlace,
                Number = number,
                Complement = complement,
                City = city,
                State = state,
                User = user
            };
        }
    }
}