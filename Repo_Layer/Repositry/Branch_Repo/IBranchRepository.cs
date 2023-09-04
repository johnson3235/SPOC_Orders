using DB_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo_Layer.Repositry.Branch_Repo
{
    public interface IBranchRepository : IRepository<Branch>
    {
        public List<Branch> GetBranchesWithDistributorAndCountry ();

        public List<Branch> FillterByCountry(int country_id);

        public List<Branch> FillterByDistributor(int Dis_id);

        public List<Branch> FillterByDistributorAndCountry(int Dis_id, int country_id);
    }
}
