using DB_Layer.Models;
using Repo_Layer.Repositry;
using Services_Layer.DTOS.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.Services.Product_Services
{
    public interface IProductServices : IService<Product>
    {

        public List<Product> GetProducts();

        public Product? GetByID(int id);

        public Product Add(ProductDTO Product);

        public bool Update(int id, UpdateProductDTO NewProduct);

        public bool Remove(int id);
    }
}
