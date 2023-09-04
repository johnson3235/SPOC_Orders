using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB_Layer.Models
{
    public class CustomUser : IdentityUser<int>
    {
  

        [Required]
        [ForeignKey("Role")]
        public int RoleId { get; set; }

        [ForeignKey("CustomUser")]
        public int? ManagerId { get; set; } = null;

        
        public virtual CustomUser? Manager { get; set; }
    }
}
