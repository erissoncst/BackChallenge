using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("categories")]
    public class Category
    {
        [Key]
        [Column("category_id")]
        public Int64 CategoryId { get; set; }

        [Column("name")]
        public String Name { get; set; }

        [Column("initial")]
        public String Initial { get; set; }

        [Column("value_per_hour")]
        public Double ValuePerHour { get; set; }

        public virtual IEnumerable<Model> Models { get; set; }

        public static Category Of(String name, String initial, Double valuePerHour)
        {
            return new Category
            {
                Name = name,
                Initial = initial,
                ValuePerHour = valuePerHour,
            };
        }

    }
}
