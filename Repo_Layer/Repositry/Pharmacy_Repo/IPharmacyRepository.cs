using DB_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo_Layer.Repositry.Pharmacy_Repo
{
    public interface IPharmacyRepository : IRepository<Pharmacy>
    {
        public List<Pharmacy> FillterByCountry(int country_id);
    }
}
