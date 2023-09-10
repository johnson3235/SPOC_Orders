using DB_Layer.Models;
using Repo_Layer.Repositry;
using Services_Layer.DTOS.Products;
using Services_Layer.Response_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.Services.Product_Services
{
    public interface IProductServices : IService<Product>
    {

        public GenericResponse<List<Product>> GetProducts();



        public GenericResponse<Product?> GetByID(int id);


        public GenericResponse<Product?> Add(ProductDTO Product);



        public GenericResponse<bool> Update(int id, UpdateProductDTO NewProduct);
        


        public GenericResponse<bool> Remove(int id);
    }
}
