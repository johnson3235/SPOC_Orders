//using Services_Layer.Custom_Validations;
using System.ComponentModel.DataAnnotations;

namespace DB_Layer.Models
{
    public class Country
    {
        [Required]
        public int Id { get; set; }

        //[UniquePropertyForUpdateAttribute(ValidationModel.Country, nameof(Id))]
        public string Name { get; set; }

    }
}
