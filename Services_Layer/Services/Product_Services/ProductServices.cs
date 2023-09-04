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


        public List<Product> GetProducts()
        {
            List<Product> pro_list = _unitofwork.Product_Repo.GetAll();

            return pro_list;
        }



        public Product? GetByID(int id)
        {
            Product pro = _unitofwork.Product_Repo.Get(id);
            if (pro != null)
            {
                return pro;
            }
            else
            { return null; }

        }


        public Product Add(ProductDTO Product)
        {
            Product pro = _mapper.Map<Product>(Product);
            _unitofwork.Product_Repo.Insert(pro);
            _unitofwork.Save();
            return pro;
        }



        public bool Update(int id, UpdateProductDTO NewProduct)
        {

            if (id == NewProduct.Id)
            {
                _unitofwork.Product_Repo.Update(_mapper.Map<Product>(NewProduct));
                _unitofwork.Save();
                return true;
            }
            return false;
        }


        public bool Remove(int id)
        {
            Product pro = _unitofwork.Product_Repo.Get(id);
            if (pro != null)
            {
                _unitofwork.Product_Repo.Delete(id);
                _unitofwork.Save();
                return true;
            }
            return false;

        }



    }
}
