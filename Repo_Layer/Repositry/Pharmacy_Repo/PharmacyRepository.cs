using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_Layer.Models;
using Microsoft.EntityFrameworkCore;

namespace Repo_Layer.Repositry.Pharmacy_Repo
{
    public class PharmacyRepository : Repository<Pharmacy>, IPharmacyRepository
    {
        private readonly DataDbContext context;
        public PharmacyRepository(DataDbContext context) : base(context)
        {
            this.context = context;
        }
        public void Delete(int id)
        {
            context.Remove(Get(id));
        }

        public Pharmacy Get(int id)
        {
            return context.Pharmacies.Find(id);
        }


        public List<Pharmacy> GetAll(string includes = null)
        {
            return includes != null ? context.Pharmacies.Include(includes).ToList() : context.Pharmacies.ToList();
        }

        public void Insert(Pharmacy obj)
        {
            context.Add(obj);
        }


        public void Update(Pharmacy obj)
        {
            context.Update(obj);
        }

        public List<Pharmacy> FillterByCountry(int country_id)
        {
            return context.Pharmacies.Include("Country").Where(c => c.ConId == country_id).ToList();
        }
        




    }
}
