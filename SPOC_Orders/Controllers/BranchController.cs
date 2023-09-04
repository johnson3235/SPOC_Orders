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
        public ActionResult<List<BranchWithDistributorAndCountry>> GetBranches()
        {
            List<BranchWithDistributorAndCountry> con_list = Branch_services.GetBranches();

            return Ok(con_list);
        }

        [HttpGet("{id:int}")]
        // [Authorize]
        public ActionResult<BranchWithDistributorAndCountry> GetByID(int id)
        {
            BranchWithDistributorAndCountry con = Branch_services.GetByID(id);
            if (con != null)
            {
                return Ok(con);
            }
            else
            { return BadRequest("Invalid Id"); }

        }

        [HttpGet("fillter/country/{id:int}")]
        // [Authorize]
        public ActionResult<List<BranchWithDistributorAndCountry>> GetByCountryID(int id)
        {
            List<BranchWithDistributorAndCountry> con = Branch_services.FillterByCountry(id);
            return Ok(con);

        }

        [HttpGet("fillter/distributor/{id:int}")]
        // [Authorize]
        public ActionResult<List<BranchWithDistributorAndCountry>> GetByDistributorID(int id)
        {
             List < BranchWithDistributorAndCountry > con = Branch_services.FillterByDistrbutor(id);

                return Ok(con);
        }


        [HttpGet("fillter/{distributor_id:int}/{country_id:int}")]
       // [Authorize]
        public ActionResult<List<BranchWithDistributorAndCountry>> GetByDisAndConID(int distributor_id, int country_id)
        {
            List<BranchWithDistributorAndCountry> con = Branch_services.FillterByCountryAndDistributor(distributor_id, country_id);

                return Ok(con);
        }

        [HttpPost]
        // [Authorize]
        public IActionResult Add(BranchDTO con)
        {
           var con2 = Branch_services.Add(con);
            
            return CreatedAtAction(
                "GetByID",
                new { id = con2.Id }
                , con);
        }



        [HttpPut("{id}")]
        //[Authorize]
        public IActionResult Update(int id, UpdateBranchDTO NewBranch)
        {


            bool complete = Branch_services.Update(id, NewBranch);
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

            bool complete = Branch_services.Remove(ID);
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
