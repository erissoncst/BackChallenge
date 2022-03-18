using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("checkouts")]
    public class CheckOut
    {

        [Key]
        [Column("checkout_id")]
        public Int64 CheckoutId { get; set; }

        public CheckIn CheckIn { get; set; }

        [Column("checkin_id")]
        public Int64 CheckinId { get; set; }

        [Column("clean_car")]
        public Boolean CleanCar { get; set; }

        [Column("full_tank")]
        public Boolean FullTank { get; set; }

        [Column("no_dents")]
        public Boolean NoDents { get; set; }

        [Column("no_scratches")]
        public Boolean NoScratches { get; set; }

    }
}
