using DB_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.DTOS.Pharmacies
{
    public class GetPharmciesWithCountry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manager_name { get; set; }
        public string Location { get; set; }

        public string? x_loc { get; set; }

        public string? y_loc { get; set; }

        public Country Country { get; set; }
    }
}
