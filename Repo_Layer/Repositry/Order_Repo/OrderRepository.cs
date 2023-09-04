using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_Layer.Models;
using Microsoft.EntityFrameworkCore;

namespace Repo_Layer.Repositry.Order_Repo
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly DataDbContext context;
        public OrderRepository(DataDbContext context) : base(context)
        {
            this.context = context;
        }
        public void Delete(int id)
        {
            context.Remove(Get(id));
        }

        public Order Get(int id)
        {
            return context.Order.Find(id);
        }

        public Order GetAllDataForId(int id)
        {
            return context.Order.Include("Country").Include("Branch").Include("Pharmacy").Include("DM").Include("MedRep").Include(o => o.OrderProducts).Where(c=>c.Id == id).FirstOrDefault();
        }


        public List<Order> GetAll(string includes = null)
        {
            return includes != null ? context.Order.Include(includes).ToList() : context.Order.ToList();
        }

        public List<Order> GetOrdersWithData()
        {
            return context.Order.Include("Country").Include("Branch").Include("Pharmacy").Include("DM").Include("MedRep").Include(o => o.OrderProducts).ToList();
        }
        

        public void Insert(Order obj)
        {
            context.Add(obj);
        }


        public void Update(Order obj)
        {
            context.Update(obj);
        }

        public List<Order> FillterByCountry(int country_id)
        {
            return context.Order.Include("Distributor").Include("Country").Where(c => c.CountryId == country_id).ToList();
        }






    }
}
