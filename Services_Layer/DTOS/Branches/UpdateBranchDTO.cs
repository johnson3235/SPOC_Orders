using Services_Layer.Custom_Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.DTOS.Branches
{
    public class BranchDTO
    {
        [Required, MaxLength(255)]
        [UniqueOrderName(ValidationModel.Branch, ErrorMessage = "Branch name must be unique.")]
        public string Name { get; set; }


        [ExistsProperty(ValidationModel.Country)]
        public int Country_id { get; set; }

        [ExistsProperty(ValidationModel.Distributor)]
        public int Distributor_id { get; set; }
    }
}
