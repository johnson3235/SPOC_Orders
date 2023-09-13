using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DB_Layer.Models;
using Repo_Layer.Repositry;
using Services_Layer.DTOS.Products;
using Services_Layer.Services.Product_Services;
using Services_Layer.Response_Model;

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
       // [Authorize]
        public ActionResult<GenericResponse<List<Product>>> GetProducts()
        {
            GenericResponse<List<Product>> pro_list = services.GetProducts();
           
            return Ok(pro_list);
        }


        [HttpGet("{id:int}")]
      //  [Authorize]
        public ActionResult<GenericResponse<Product>?> GetByID(int id)
        {
           GenericResponse<Product>? pro = services.GetByID(id);
            if (pro.Data != null)
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
            GenericResponse<Product>? pro =  services.Add(Product);

            if (pro.Data != null)
            {
                return CreatedAtAction(
    "GetByID",
    new { id = pro.Data.Id }
    , pro);
            }
            else
            { return BadRequest("Some Thing Error"); }

        }



        [HttpPut("{id}")]
      //  [Authorize]
        public IActionResult Update(int id, UpdateProductDTO NewProduct)
        {

            if (id == NewProduct.Id)
            {

                var complete = services.Update(id, NewProduct);
                if (complete.Data == true)
                {
                    return Ok(complete);
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
            var complete = services.Remove(ProductID);
            if(complete.Data == true)
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

