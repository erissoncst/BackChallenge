using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("models")]
    public class Model
    {
        [Key]
        [Column("model_id")]
        public Int64 ModelId { get; set; }

        [Column("brand_id")]
        public Int64 BrandId { get; set; }
        
        public Brand Brand { get; set; }

        [Column("category_id")]
        public Int64 CategoryId { get; set; }

        public Category Category { get; set; }

        [Column("name")]
        public String Name { get; set; }

        [Column("fuel")]
        public FuelType Fuel { get; set; }

        [Column("trunk_car_size")]
        public TrunkCarSize TrunkCarSize { get; set; }

        [Column("image")]
        public String Image { get; set; }

        public virtual IEnumerable<Car> Cars { get; set; }

        public static Model Of(String name, FuelType fuel, TrunkCarSize trunkCarSize, String image, Category category, Brand brand)
        {
            return new Model
            {
                Name = name,
                Category = category,
                Brand = brand,
                Fuel = fuel,
                Image= image,
                TrunkCarSize = trunkCarSize,
            };
        }
    }
}
