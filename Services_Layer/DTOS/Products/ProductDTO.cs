
using Services_Layer.Custom_Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.DTOS.Products
{
    public class ProductDTO
    {
        [Required, MaxLength(25), MinLength(3, ErrorMessage = "Name must be more than 2 char")]
        [UniqueOrderName(ValidationModel.Product, ErrorMessage = "Product name must be unique.")]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; } = "No Description";

        [Required]
        [Range(minimum: 1, maximum: 50000)]
        public int Price { get; set; }

    }
}
