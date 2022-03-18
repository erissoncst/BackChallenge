using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("cars")]
    public class Car
    {
        [Key]
        [Column("car_id")]
        public Int64 CarId { get; set; }

        [Column("model_id")]
        public Int64 ModelId { get; set; }

        public Model Model { get; set; }

        [Column("year_manufacture")]
        public Int16 YearManufacture { get; set; }

        [Column("color")]
        public String Color { get; set; }

        [Column("license_plate")]
        public String LicensePlate { get; set; }

        public ICollection<CheckIn> CheckIns { get; set; }

        public static Car Of(Model model, Int16 yearManufacture, String color, String licensePlate)
        {
            return new Car
            {
                Model = model,
                YearManufacture = yearManufacture,
                Color = color,
                LicensePlate = licensePlate
            };
        }
    }
}
