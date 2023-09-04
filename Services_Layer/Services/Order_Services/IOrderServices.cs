using DB_Layer.Models;
using Services_Layer.DTOS.Branches;
using Services_Layer.DTOS.Orders;
using Services_Layer.DTOS.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.Services.Order_Services
{
    public interface IOrderServices
    {

        public List<GetOrderDTO> GetOrders();

        public GetOrderDTO? GetByID(int id);
        public  Task<Order?> Add(AddOrderDTO Order);

       // public Task<string> Update(int id, UpdateOrderDTO Order);
       public  Task<bool> Update(int id, UpdateOrderDTO Order);

        public bool Remove(int ID);
    }
}
