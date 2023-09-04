using Services_Layer.Custom_Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.DTOS.Distributor
{
    public class DistributorDTO
    {
        [Required, MaxLength(255)]
        [UniqueOrderName(ValidationModel.Distributor, ErrorMessage = "Distributor name must be unique.")]
        public string Name { get; set; }
    }
}
