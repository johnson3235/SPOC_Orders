
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
    public class CountryDTO
    {
        [Required, MaxLength(255)]
        [UniqueOrderName(ValidationModel.Country, ErrorMessage = "Country name must be unique.")]
        public string Name { get; set; }



    }
}
