using DB_Layer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace Services_Layer.DTOS.Branches
{
    public class BranchWithDistributorAndCountry
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Country? Country { get; set; }

        public virtual DB_Layer.Models.Distributor? Distributor { get; set; }
    }
}
