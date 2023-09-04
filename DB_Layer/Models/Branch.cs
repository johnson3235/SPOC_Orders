using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DB_Layer.Models
{
    public class Branch
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        [ForeignKey("Distributor")]
        public int DisId { get; set; }


        [Required]
        [ForeignKey("Country")]
        public int ConId { get; set; }

        public virtual Country? Country { get; set; }

        public virtual Distributor? Distributor { get; set; }
    }

}
