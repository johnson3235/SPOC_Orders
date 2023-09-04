using DB_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.DTOS.User
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public virtual CustomUser? Manager { get; set; }
    }
}
