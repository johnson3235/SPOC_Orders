using AutoMapper;
using DB_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using Repo_Layer.UnitOfWork;
using Services_Layer.DTOS.Branches;
using Services_Layer.DTOS.Orders;
using Services_Layer.DTOS.Products;
using Services_Layer.DTOS.User;
using Services_Layer.Response_Model;
using Services_Layer.Services.Country_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.Services.Order_Services
{
    public class OrderServices : Service<Order>, IOrderServices
    {
        private readonly IUnitOFWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderServices(IUnitOFWork _unitofwork, IMapper _mapper) : base(_unitofwork, _mapper)
        {
            this._unitOfWork = _unitofwork;
            this._mapper = _mapper;
        }


        public GenericResponse<List<GetOrderDTO>> GetOrders()
        {
            List<Order> order_list = _unitOfWork.Order_Repo.GetOrdersWithData();



            List<GetOrderDTO> order_DTO = new List<GetOrderDTO>();
            foreach (var order in order_list)
            {
                //order.MedRep = _mapper.Map<UserDTO>(order.MedRep);
                foreach(var product_order in order.OrderProducts)
                {
                    product_order.Product = _unitOfWork.Product_Repo.Get(product_order.ProductId);
                }
                order_DTO.Add(_mapper.Map<GetOrderDTO>(order));
            }

            return new GenericResponse<List<GetOrderDTO>>() { Data = order_DTO , Message="Get Orders Successfully"};

        }



        public GenericResponse<GetOrderDTO?> GetByID(int id)
        {
            Order order = _unitOfWork.Order_Repo.GetAllDataForId(id);

            if (order != null)
            {
                GetOrderDTO order_DTO = _mapper.Map<GetOrderDTO>(order);
                return new GenericResponse<GetOrderDTO?>() { Data= order_DTO, Message = "Get Order Successfully"};
            }
            else
            { return new GenericResponse<GetOrderDTO?>() { Data = null, Message = "Get Order Successfully" }; ; }

        }

        public async Task<GenericResponse<Order?>> Add(AddOrderDTO Order)
        {


            var order = _mapper.Map<Order>(Order);
            order.OrderProducts = null;
            _unitOfWork.Order_Repo.Insert(order);

            try
            {
                 _unitOfWork.Save();

                foreach (var order_product in Order.OrderProducts)
                {

                    Order_Products orderProduct = new Order_Products
                    {
                        OrderId = order.Id,
                        ProductId = order_product.ProductId,
                        quantity = order_product.quantity,
                        totalprice = order_product.totalprice
                    };
                    _unitOfWork.Order_Products_Repo.Insert(orderProduct);
                }

                int savedChanges =   _unitOfWork.Save();
                
                if (savedChanges > 0)
                {
                    return new GenericResponse<Order?>() { Data = order, Message = "Added Order Successfully" }; 
                }
                else
                {
                    return new GenericResponse<Order?>() { Data = null, Message = "Added Order Failed" };
                }
            }
            catch (Exception ex)
            {
                return new GenericResponse<Order?>() { Data = null, Message = "Added Order Failed" };
            }

        }



        public async Task<GenericResponse<bool>> Update(int id, UpdateOrderDTO Order)
        {

            var find_order = _unitOfWork.Order_Repo.Get(id);
            if(find_order != null)
            {
                find_order.Name = Order.Name;
                find_order.DMId = Order.DMId;
                find_order.MedRepId = Order.MedRepId;
                find_order.PharmacyId = Order.PharmacyId;
                find_order.BranchId = Order.BranchId;
                find_order.CountryId = Order.CountryId;
             //   Order order = new Order{ Id = Order.Id , Name = Order.Name , DMId = Order.DMId , MedRepId = Order.MedRepId , CountryId = Order.CountryId , PharmacyId = Order.PharmacyId };
                _unitOfWork.Order_Repo.Update(find_order);

                try
                {

                     _unitOfWork.Save();



                    foreach (var order_product in Order.OrderProducts)
                    {
                        var orderProduct = new Order_Products
                        {
                            OrderId = find_order.Id,
                            ProductId = order_product.ProductId,
                            quantity = order_product.quantity,
                            totalprice = order_product.totalprice
                        };
                        _unitOfWork.Order_Products_Repo.Update(orderProduct);

                      
                    }

                    int savedChanges = _unitOfWork.Save();
                   


                    if (savedChanges > 0)
                    {
                        return new GenericResponse<bool>() { Message = "Updated Order Successfully", Data = true };
                    }
                    else
                    {
                        return new GenericResponse<bool>() { Message = "Updated Order Failed", Data = false };
                    }
                    
                }
                catch (Exception ex)
                {
                    return new GenericResponse<bool>() { Message = "Updated Order Failed Exception", Data = false };
                }
        }
            return new GenericResponse<bool>() { Message = "Updated Order Failed", Data = false };

        }


        public GenericResponse<bool> Remove(int ID)
        {
            var order = _unitOfWork.Order_Repo.Get(ID);
            if (order != null)
            {
                _unitOfWork.Order_Repo.Delete(ID);
                _unitOfWork.Save();
                var res = new GenericResponse<bool>() { Message = "Deleted Country Successfully", Data = true };
                return res;

            }
            var response = new GenericResponse<bool>() { Message = "Delete Country Failed", Data = false };
            return response;
        }


    }
}
