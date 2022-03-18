using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("brands")]
    public class Brand
    {
        [Key]
        [Column("brand_id")]
        public Int64 BrandId { get; set; }

        [Column("name")]
        public String Name { get; set; }

        public static Brand Of(String name)
        {
            return new Brand { Name = name };
        }

    }
}
