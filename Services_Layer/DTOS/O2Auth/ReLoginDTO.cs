using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.DTOS.O2Auth
{
    public class ReLoginDTO
    {
        public string RefreshToken { get; set; }
        public string Email { get; set; }
    }
}
