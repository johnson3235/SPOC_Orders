using Services_Layer.Custom_Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.DTOS.Pharmacies
{
    public class UpdatePharmacyDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Manager Name must be more than 2 char")]
        [UniquePropertyForUpdateAttribute(ValidationModel.Pharmacy, nameof(Id))]
        public string Name { get; set; }
        [Required, MaxLength(25), MinLength(3, ErrorMessage = "Manager Name must be more than 2 char")]
        public string Manager_name { get; set; }
        [Required]
        public string Location { get; set; }

        public string? x_loc { get; set; }

        public string? y_loc { get; set; }

        [ExistsProperty(ValidationModel.Country)]
        public int Country_id { get; set; }
    }
}
