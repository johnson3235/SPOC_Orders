//using Services_Layer.Custom_Validations;
using System.ComponentModel.DataAnnotations;

namespace DB_Layer.Models
{
    public class Role
    {
        [Required]
        public int Id { get; set; }

        //[UniquePropertyForUpdateAttribute(ValidationModel.Role, nameof(Id))]
        public string Name { get; set; }
    }
}
