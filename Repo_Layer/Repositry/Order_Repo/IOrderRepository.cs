using DB_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo_Layer.Repositry.Order_Repo
{
    public interface IOrderRepository : IRepository<Order>
    {
        public List<Order> GetOrdersWithData();

        public Order GetAllDataForId(int id);
        public List<Order> FillterByCountry(int country_id);

    //    public List<Branch> FillterByDistributor(int Dis_id);

    //    public List<Branch> FillterByDistributorAndCountry(int Dis_id, int country_id);
    }
}
