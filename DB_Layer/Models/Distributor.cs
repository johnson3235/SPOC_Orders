//using Services_Layer.Custom_Validations;
using System.ComponentModel.DataAnnotations;

namespace DB_Layer.Models
{
    public class Distributor
    {
        [Required]
        public int ID { get; set; }

        //[UniquePropertyForUpdateAttribute(ValidationModel.Distributor, nameof(ID))]
        public string Name { get; set; }


    }
}
