using Services_Layer.Custom_Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.DTOS.Branches
{
    public class UpdateBranchDTO
    {
        [Required]
        
        public int Id { get; set; }

        [Required, MaxLength(255)]
        [UniquePropertyForUpdateAttribute(ValidationModel.Branch, nameof(Id))]
        public string Name { get; set; }


        [ExistsProperty(ValidationModel.Country)]
        public int Country_id { get; set; }

        [ExistsProperty(ValidationModel.Distributor)]
        public int Distributor_id { get; set; }
    }
}
