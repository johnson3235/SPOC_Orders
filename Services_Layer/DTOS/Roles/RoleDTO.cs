using Services_Layer.Custom_Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.DTOS.Distributor
{
    public class RoleDTO
    {
        [Required, MaxLength(255)]
        [UniqueOrderName(ValidationModel.Role, ErrorMessage = "Role name must be unique.")]
        public string Name { get; set; }
    }
}
