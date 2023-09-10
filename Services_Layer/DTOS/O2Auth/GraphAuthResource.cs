using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.DTOS.O2Auth
{
    public class GraphAuthResource
    {
        //Error
        public string error { get; set; }
        public string error_description { get; set; }
        public int[] error_codes { get; set; }

        //Success
        public string access_token { get; set; }
        public string refresh_token { get; set; }
    }
}
