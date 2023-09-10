using DB_Layer.Models;
using Services_Layer.DTOS.Branches;
using Services_Layer.DTOS.Orders;
using Services_Layer.DTOS.Products;
using Services_Layer.Response_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.Services.Order_Services
{
    public interface IOrderServices
    {

        public GenericResponse<List<GetOrderDTO>> GetOrders();



        public GenericResponse<GetOrderDTO?> GetByID(int id);

        public  Task<GenericResponse<Order?>> Add(AddOrderDTO Order);



        public  Task<GenericResponse<bool>> Update(int id, UpdateOrderDTO Order);


        public GenericResponse<bool> Remove(int ID);
    }
}
