using DB_Layer.Models;
using Services_Layer.DTOS.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repo_Layer.Repositry;
using Services_Layer.Services.Country_Services;
using Repo_Layer.Repositry.Branch_Repo;
using Services_Layer.Services.Branch_Services;
using Services_Layer.DTOS.Branches;
using System.Collections.Generic;
using Services_Layer.Response_Model;

namespace SPOC_Orders.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {

        private readonly IBranchServices Branch_services;
        public BranchController(IBranchServices Branch_services)
        {
            this.Branch_services = Branch_services;
        }



        [HttpGet]
        //[Authorize]
        public ActionResult<GenericResponse<List<BranchWithDistributorAndCountry>>> GetBranches()
        {
           var con_list = Branch_services.GetBranches();

            return Ok(con_list);
        }

        [HttpGet("{id:int}")]
        // [Authorize]
        public ActionResult<GenericResponse<BranchWithDistributorAndCountry>> GetByID(int id)
        {
            var con = Branch_services.GetByID(id);
            if (con.Data != null)
            {
                return Ok(con);
            }
            else
            { return BadRequest("Invalid Id"); }

        }

        [HttpGet("fillter/country/{id:int}")]
        // [Authorize]
        public ActionResult<GenericResponse<List<BranchWithDistributorAndCountry>>> GetByCountryID(int id)
        {
            var con = Branch_services.FillterByCountry(id);
            return Ok(con);

        }

        [HttpGet("fillter/distributor/{id:int}")]
        // [Authorize]
        public ActionResult<GenericResponse<List<BranchWithDistributorAndCountry>>> GetByDistributorID(int id)
        {
             var con = Branch_services.FillterByDistrbutor(id);

                return Ok(con);
        }


        [HttpGet("fillter/{distributor_id:int}/{country_id:int}")]
       // [Authorize]
        public ActionResult<GenericResponse<List<BranchWithDistributorAndCountry>>> GetByDisAndConID(int distributor_id, int country_id)
        {
            var con = Branch_services.FillterByCountryAndDistributor(distributor_id, country_id);

                return Ok(con);
        }

        [HttpPost]
        // [Authorize]
        public IActionResult Add(BranchDTO con)
        {
           var con2 = Branch_services.Add(con);
            
            return CreatedAtAction(
                "GetByID",
                new { id = con2.Data.Id }
                , con);
        }



        [HttpPut("{id}")]
        //[Authorize]
        public IActionResult Update(int id, UpdateBranchDTO NewBranch)
        {


            var complete = Branch_services.Update(id, NewBranch);
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

            var complete = Branch_services.Remove(ID);
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
