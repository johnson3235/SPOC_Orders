using Services_Layer.Custom_Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.DTOS.Pharmacies
{
    public class AddPharmacyDTO
    {

        [Required, MaxLength(25), MinLength(3, ErrorMessage = "Pharmacy Name must be more than 2 char")]
        [UniqueOrderName(ValidationModel.Pharmacy, ErrorMessage = "Pharmacy name must be unique.")]
        public string Name { get; set; }
        [Required, MaxLength(25), MinLength(3, ErrorMessage = "Manager Name must be more than 2 char")]
        public string Manager_name { get; set; }
        [Required]
        public string Location { get; set; }

        public string? x_loc { get; set; }

        public string? y_loc { get; set; }

        [ExistsProperty(ValidationModel.Country,ErrorMessage ="Country ID Dosen't Exist.")]
        public int Country_id { get; set; }
    }
}
