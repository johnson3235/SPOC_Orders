using DB_Layer.Models;
using Services_Layer.DTOS.Pharmacies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repo_Layer.Repositry;
using Services_Layer.Services.Pharmacy_Services;
using Services_Layer.Services.Product_Services;

namespace SPOC_Orders.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private readonly IPharmacyServices pharmacy_services;
        public PharmacyController(IPharmacyServices pharmacy_services)
        {
            this.pharmacy_services = pharmacy_services;
        }


        [HttpGet]
        //[Authorize]
        public ActionResult<List<GetPharmciesWithCountry>> GetPharmacies()
        {
            var phr_list = pharmacy_services.GetPharmacies();
            return Ok(phr_list);
        }


        [HttpGet("{id:int}")]
     //   [Authorize]
        public ActionResult<GetPharmciesWithCountry> GetByID(int id)
        {
            GetPharmciesWithCountry phar = pharmacy_services.GetByID(id);
           
            if (phar != null)
            {
                return Ok(phar);
            }
            else
            { return BadRequest("Invalid Id"); }

        }


        [HttpGet("FillterByCountry/{Country_id:int}")]
        //   [Authorize]
        public ActionResult<List<GetPharmciesWithCountry>> GetByCountry(int Country_id)
        {
            List<GetPharmciesWithCountry> phar_list = pharmacy_services.GetByCountry(Country_id);
            return Ok(phar_list);

        }

        [HttpPost]
        //[Authorize]
        public IActionResult Add(AddPharmacyDTO pharmacy)
        {

           Pharmacy New_Pharmacy = pharmacy_services.Add(pharmacy);
          if(New_Pharmacy != null)
            {
                // return CreatedAtAction(
                //"GetByID",
                //new { id = New_Pharmacy.Id }
                //, pharmacy);
                return Ok(New_Pharmacy);
            }
          else
            {
                return BadRequest();
            }
           
        }

        [HttpPut("{id}")]
        //[Authorize]
        public IActionResult Update(int id, UpdatePharmacyDTO pharmacy)
        {

            bool complete = pharmacy_services.Update(id, pharmacy);
            if (complete)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Invalid Id");
            }
                
        }

        [HttpDelete("{ID}")]
        //[Authorize]
        public IActionResult Remove(int ID)
        {
           bool complete = pharmacy_services.Remove(ID);
            if(complete)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
            
        }




}
}
