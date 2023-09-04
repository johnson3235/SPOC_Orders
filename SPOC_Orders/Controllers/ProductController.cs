using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DB_Layer.Models;
using Repo_Layer.Repositry;
using Services_Layer.DTOS.Products;
using Services_Layer.Services.Product_Services;

namespace SPOC_Orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices services;
        
        public ProductController(IProductServices Product_services)
        {
            this.services = Product_services;
        }


        [HttpGet]
        //[Authorize]
        public ActionResult<List<Product>> GetProducts()
        {
            List<Product> pro_list = services.GetProducts();
           
            return Ok(pro_list);
        }


        [HttpGet("{id:int}")]
      //  [Authorize]
        public ActionResult<Product> GetByID(int id)
        {
            Product? pro = services.GetByID(id);
            if (pro != null)
            {
                return Ok(pro);
            }
            else
            { return BadRequest("Invalid Id"); }

        }

        [HttpPost]
       // [Authorize]
        public IActionResult Add(ProductDTO Product)
        {
           Product pro=  services.Add(Product);
            return CreatedAtAction(
                "GetByID",
                new { id = pro.Id }
                , pro);
        }



        [HttpPut("{id}")]
      //  [Authorize]
        public IActionResult Update(int id, UpdateProductDTO NewProduct)
        {

            if (id == NewProduct.Id)
            {
                bool complete = services.Update(id, NewProduct);
                if(complete == true)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Invalid Id");
                }
            }
            return BadRequest("Invalid Id");
        }

        [HttpDelete("{ProductID}")]
       // [Authorize]
        public IActionResult Remove(int ProductID)
        {
            bool complete = services.Remove(ProductID);
            if(complete == true)
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

