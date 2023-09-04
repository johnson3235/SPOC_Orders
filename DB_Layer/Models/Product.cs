//using Services_Layer.Custom_Validations;
using System.ComponentModel.DataAnnotations;

namespace DB_Layer.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(25), MinLength(3, ErrorMessage = "Name must be more than 2 char")]
        //[UniquePropertyForUpdateAttribute(ValidationModel.Product, nameof(Id))]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; } = "No Description";

        [Required]
        [Range(minimum: 1, maximum: 50000)]
        public int Price { get; set; }

    }
}
