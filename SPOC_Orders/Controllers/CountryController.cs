using DB_Layer.Models;
using Services_Layer.DTOS.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repo_Layer.Repositry;
using Services_Layer.Services.Country_Services;

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
        public ActionResult<List<Country>> GetCountires()
        {
            List<Country> con_list = country_services.GetCountries();

            return Ok(con_list);
        }


        [HttpGet("{id:int}")]
       // [Authorize]
        public ActionResult<Country> GetByID(int id)
        {
            Country con = country_services.GetByID(id);
            if (con != null)
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
                new { id = con2.Id }
                , con);
        }



        [HttpPut("{id}")]
        //[Authorize]
        public IActionResult Update(int id, UpdateCountryDTO NewCountry)
        {


            bool complete = country_services.Update(id, NewCountry);
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

            bool complete = country_services.Remove(ID);
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
