using DB_Layer.Models;
using Services_Layer.DTOS.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repo_Layer.Repositry;
using Services_Layer.Services.Country_Services;
using Services_Layer.Response_Model;

namespace SPOC_Orders.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {

        private readonly ICountryServices country_services;
        public CountryController(ICountryServices country_services)
        {
            this.country_services = country_services;
        }



        [HttpGet]
        //[Authorize]
        public ActionResult<GenericResponse<List<Country>>> GetCountires()
        {
            var con_list = country_services.GetCountries();

            return Ok(con_list);
        }


        [HttpGet("{id:int}")]
       // [Authorize]
        public ActionResult<GenericResponse<Country>> GetByID(int id)
        {
            var con = country_services.GetByID(id);
            if (con.Data != null)
            {
                return Ok(con);
            }
            else
            { return BadRequest("Invalid Id"); }

        }

        [HttpPost]
        // [Authorize]
        public IActionResult Add(CountryDTO con)
        {
           var con2 = country_services.Add(con);
            
            return CreatedAtAction(
                "GetByID",
                new { id = con2.Data.Id }
                , con);
        }



        [HttpPut("{id}")]
        //[Authorize]
        public IActionResult Update(int id, UpdateCountryDTO NewCountry)
        {


            var complete = country_services.Update(id, NewCountry);
            if (complete.Data == true)
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

            var complete = country_services.Remove(ID);
            if (complete.Data == true)
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
