using Repo_Layer.UnitOfWork;
using Services_Layer.DTOS.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Services_Layer.Response_Model;

namespace Services_Layer.Services.Product_Services
{
    public class ProductServices : Service<Product> , IProductServices
    {
        private readonly IUnitOFWork _unitofwork;
        private readonly IMapper _mapper;

        public ProductServices(IUnitOFWork _unitofwork , IMapper _mapper) : base(_unitofwork,_mapper)
        {
            this._unitofwork = _unitofwork;
            this._mapper = _mapper;
        }


        public GenericResponse<List<Product>> GetProducts()
        {
            List<Product> pro_list = _unitofwork.Product_Repo.GetAll();
            var response = new GenericResponse<List<Product>>() { Message = "Get Products Successfully", Data = pro_list };
            return response;
        }



        public GenericResponse<Product?> GetByID(int id)
        {
            Product pro = _unitofwork.Product_Repo.Get(id);
           
            if (pro != null)
            {
                var response = new GenericResponse<Product?>() { Message = "Get Product Successfully", Data = pro };
                return response;
            }
            else
            {
                var response = new GenericResponse<Product?>() { Message = "Add Role Failed", Data = null  }; 
                return response; 
            }

        }


        public GenericResponse<Product?> Add(ProductDTO Product)
        {
            Product pro = _mapper.Map<Product>(Product);
            _unitofwork.Product_Repo.Insert(pro);

            try
            {
                int savedChanges = _unitofwork.Save();

                if (savedChanges > 0)
                {
                    var response = new GenericResponse<Product?>() { Message = "Add Product Successfully", Data = pro };
                    return response;
                }
                else
                {
                    var response = new GenericResponse<Product?>() { Message = "Add Role Failed", Data = null };
                    return response;
                }
            }
            catch (Exception ex)
            {
                var response = new GenericResponse<Product?>() { Message = "Add Role Failed Exception", Data = null };
                return response;
            }
           
        }



        public GenericResponse<bool> Update(int id, UpdateProductDTO NewProduct)
        {

            if (id == NewProduct.Id)
            {
                _unitofwork.Product_Repo.Update(_mapper.Map<Product>(NewProduct));
                _unitofwork.Save();
                var res = new GenericResponse<bool>() { Message = "Updated Product Successfully", Data = true };
                return res;

            }
            var response = new GenericResponse<bool>() { Message = "Update Product Failed", Data = false };
            return response;

        }


        public GenericResponse<bool> Remove(int id)
        {
            Product pro = _unitofwork.Product_Repo.Get(id);
            if (pro != null)
            {
                _unitofwork.Product_Repo.Delete(id);
                _unitofwork.Save();
                var res = new GenericResponse<bool>() { Message = "Deleted Product Successfully", Data = true };
                return res;

            }
            var response = new GenericResponse<bool>() { Message = "Deleted Product Failed", Data = false };
            return response;

        }



    }
}
