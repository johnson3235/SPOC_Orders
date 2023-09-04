using DB_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using Services_Layer.DTOS.Distributor;
using Services_Layer.DTOS.Products;
using Services_Layer.Services.Country_Services;
using Services_Layer.Services.Distributor_Services;

namespace SPOC_Orders.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DistributorController : ControllerBase
    {
        private readonly IDistributorServices Distributor_services;
        public DistributorController(IDistributorServices Distributor_services)
        {
            this.Distributor_services = Distributor_services;
        }



        [HttpGet]
        //[Authorize]
        public ActionResult<List<Distributor>> GetDistributors()
        {
            List<Distributor> con_list = Distributor_services.GetDistributors();

            return Ok(con_list);
        }


        [HttpGet("{id:int}")]
        // [Authorize]
        public ActionResult<Distributor> GetByID(int id)
        {
            Distributor con = Distributor_services.GetByID(id);
            if (con != null)
            {
                return Ok(con);
            }
            else
            { return BadRequest("Invalid Id"); }

        }

        [HttpPost]
        // [Authorize]
        public IActionResult Add(DistributorDTO con)
        {
            var con2 = Distributor_services.Add(con);

            return CreatedAtAction(
                "GetByID",
                new { id = con2.ID }
                , con);
        }



        [HttpPut("{id}")]
        //[Authorize]
        public IActionResult Update(int id, UpdateDistributorDTO NewDistributor)
        {


            bool complete = Distributor_services.Update(id, NewDistributor);
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

            bool complete = Distributor_services.Remove(ID);
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
