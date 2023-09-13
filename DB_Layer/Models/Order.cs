using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DB_Layer.Models
{
    public class Order
    {
        [Required]
        public int Id { get; set; }

        [Required]

        public string Name { get; set; }

        public string Description { get; set; }
        [Required]
        public decimal totalprice { get; set; }

        [Required]
        [ForeignKey("CustomUser")]
        public int MedRepId { get; set; }

        [Required]
        [ForeignKey("CustomUser")]
        public int DMId { get; set; }

        [Required]
        [ForeignKey("Pharmacy")]
        public int PharmacyId { get; set; }

        [Required]
        [ForeignKey("Branch")]
        public int BranchId { get; set; }

        [Required]
        [ForeignKey("Country")]
        public int CountryId { get; set; }


        public virtual CustomUser MedRep { get; set; }

        public virtual CustomUser DM { get; set; }

        public virtual Pharmacy? Pharmacy { get; set; }

        public virtual Branch? Branch { get; set; }

        public virtual Country? Country { get; set; }

        public virtual List<Order_Products> OrderProducts { get; set; }


    }
}
