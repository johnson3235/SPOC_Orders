using DB_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using Services_Layer.DTOS.Branches;
using Services_Layer.DTOS.Orders;
using Services_Layer.DTOS.Pharmacies;
using Services_Layer.Response_Model;
using Services_Layer.Services.Branch_Services;
using Services_Layer.Services.Order_Services;

namespace SPOC_Orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderServices Order_services;
        public OrderController(IOrderServices Order_services)
        {
            this.Order_services = Order_services;
        }

        [HttpGet]
        //[Authorize]
        public ActionResult<GenericResponse<List<GetOrderDTO>>> GetOrders()
        {
            var phr_list = Order_services.GetOrders();
            return Ok(phr_list);
        }


        [HttpGet("{id:int}")]
        //   [Authorize]
        public ActionResult<GenericResponse<GetOrderDTO>> GetByID(int id)
        {
            var phar = Order_services.GetByID(id);

            if (phar.Data != null)
            {
                return Ok(phar);
            }
            else
            { return BadRequest("Invalid Id"); }

        }


        //[HttpGet("FillterByCountry/{Country_id:int}")]
        ////   [Authorize]
        //public ActionResult<List<GetPharmciesWithCountry>> GetByCountry(int Country_id)
        //{
        //    List<GetPharmciesWithCountry> phar_list = pharmacy_services.GetByCountry(Country_id);
        //    return Ok(phar_list);

        //}

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Add(AddOrderDTO order)
        {

            var New_Order = await Order_services.Add(order);
            if (New_Order.Data != null)
            {
                // return CreatedAtAction(
                //"GetByID",
                //new { id = New_Pharmacy.Id }
                //, pharmacy);
                return Ok(New_Order);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> Update(int id, UpdateOrderDTO order)
        {

           var complete = await Order_services.Update(id, order);
         
            if (complete.Data)
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
            var complete = Order_services.Remove(ID);
            if (complete.Data)
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
