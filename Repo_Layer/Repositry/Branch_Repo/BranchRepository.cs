using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_Layer.Models;
using Microsoft.EntityFrameworkCore;

namespace Repo_Layer.Repositry.Branch_Repo
{
    public class BranchRepository : Repository<Branch>, IBranchRepository
    {
        private readonly DataDbContext context;
        public BranchRepository(DataDbContext context) : base(context)
        {
            this.context = context;
        }
        public void Delete(int id)
        {
            context.Remove(Get(id));
        }

        public Branch Get(int id)
        {
            return context.Branches.Find(id);
        }


        public List<Branch> GetAll(string includes = null)
        {
            return includes != null ? context.Branches.Include(includes).ToList() : context.Branches.ToList();
        }

        public List<Branch> GetBranchesWithDistributorAndCountry()
        {
            return context.Branches.Include("Distributor").Include("Country").ToList();
        }


        public void Insert(Branch obj)
        {
            context.Add(obj);
        }


        public void Update(Branch obj)
        {
            context.Update(obj);
        }

        public List<Branch> FillterByCountry(int country_id)
        {
            return context.Branches.Include("Distributor").Include("Country").Where(c => c.ConId == country_id).ToList();
        }

        public List<Branch> FillterByDistributor(int Dis_id)
        {
            return context.Branches.Include("Distributor").Include("Country").Where(c => c.DisId == Dis_id).ToList();
        }

        public List<Branch> FillterByDistributorAndCountry(int Dis_id , int country_id)
        {
            return context.Branches.Include("Distributor").Include("Country").Where(c => c.DisId == Dis_id).Where(c=>c.ConId == country_id).ToList();
        }





    }
}
