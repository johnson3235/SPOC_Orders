using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DB_Layer.Models
{
    public class Pharmacy
    {
        [Required]
        public int Id { get; set; }

        [Required, MaxLength(25), MinLength(3, ErrorMessage = "Name must be more than 2 char")]
        public string Name { get; set; }

        [Required, MaxLength(25), MinLength(3, ErrorMessage = "Manager Name must be more than 2 char")]
        public string Manager_name { get; set; }

        [Required]
        public string Location { get; set; }

        public string? x_loc { get; set; }

        public string? y_loc { get; set; }


        [ForeignKey("Country")]
        public int ConId { get; set; }

        public virtual Country? Country { get; set; }
    }
}
