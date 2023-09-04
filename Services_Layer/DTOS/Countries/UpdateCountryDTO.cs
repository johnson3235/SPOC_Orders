
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
    public class UpdateCountryDTO
    {
        [Required]
        public int Id { get; set; }
        [Required, MaxLength(255)]
        [UniquePropertyForUpdateAttribute(ValidationModel.Country, nameof(Id))]
        public string Name { get; set; }



    }
}
