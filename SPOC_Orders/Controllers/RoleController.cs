using DB_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using Services_Layer.DTOS.Distributor;
using Services_Layer.DTOS.Products;
using Services_Layer.Response_Model;
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
        public ActionResult<GenericResponse<List<Role>>> GetRoles()
        {
            GenericResponse<List<Role>> con_list = Role_services.GetRoles();
           
            return Ok(con_list);
        }


        [HttpGet("{id:int}")]
        // [Authorize]
        public ActionResult<GenericResponse<Role?>> GetByID(int id)
        {
            GenericResponse<Role?> con = Role_services.GetByID(id);
            if (con.Data != null)
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
                new { id = con2.Data.Id }
                , con);
        }



        [HttpPut("{id}")]
        //[Authorize]
        public IActionResult Update(int id, UpdateRoleDTO NewRole)
        {

                var complete = Role_services.Update(id, NewRole);
                if (complete.Data == true)
                {
                    return Ok(complete);
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

            var complete = Role_services.Remove(ID);
            if (complete.Data == true)
            {
                return Ok(complete);
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }


    }
}
