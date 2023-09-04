using DB_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using Services_Layer.DTOS.Distributor;
using Services_Layer.DTOS.Products;
using Services_Layer.Services.Distributor_Services;
using Services_Layer.Services.Role_Services;

namespace SPOC_Orders.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleServices Role_services;
        public RoleController(IRoleServices Role_services)
        {
            this.Role_services = Role_services;
        }

        [HttpGet]
        //[Authorize]
        public ActionResult<List<Role>> GetRoles()
        {
            List<Role> con_list = Role_services.GetRoles();

            return Ok(con_list);
        }


        [HttpGet("{id:int}")]
        // [Authorize]
        public ActionResult<Role> GetByID(int id)
        {
            Role con = Role_services.GetByID(id);
            if (con != null)
            {
                return Ok(con);
            }
            else
            { return BadRequest("Invalid Id"); }

        }

        [HttpPost]
        // [Authorize]
        public IActionResult Add(RoleDTO con)
        {
            var con2 = Role_services.Add(con);

            return CreatedAtAction(
                "GetByID",
                new { id = con2.Id }
                , con);
        }



        [HttpPut("{id}")]
        //[Authorize]
        public IActionResult Update(int id, UpdateRoleDTO NewRole)
        {

                bool complete = Role_services.Update(id, NewRole);
                if (complete == true)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Invalid Id");
                }
 
        }

        [HttpDelete("{ID}")]
        // [Authorize]
        public IActionResult Remove(int ID)
        {

            bool complete = Role_services.Remove(ID);
            if (complete == true)
            {
                return NoContent();
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }


    }
}
