using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.DTOS.User
{
    public class tokenDTO
    {
        public string token { get; set; }
        public DateTime expired_date { get; set; }

    }
}
