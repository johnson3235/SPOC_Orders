using DB_Layer.Models;
using Services_Layer.Custom_Validations;
using Services_Layer.DTOS.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.DTOS.Branches
{
    public class GetOrderDTO
    {
        [Required]
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual UserDTO? MedRep { get; set; }

        public virtual UserDTO? DM { get; set; }

        public virtual Pharmacy? pharmacy { get; set; }

        public virtual Branch? Branch { get; set; }

        public virtual Country? Country { get; set; }

        public virtual List<Order_Products> OrderProducts { get; set; }


        //[CountryExists(ErrorMessage = "Country ID does not exist.")]
        //public int Country_id { get; set; }

        //[DistributorExists(ErrorMessage = "Distributor ID does not exist.")]
        //public int Distributor_id { get; set; }
    }
}
