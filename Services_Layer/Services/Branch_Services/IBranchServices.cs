using DB_Layer.Models;
using Services_Layer.DTOS.Branches;
using Services_Layer.DTOS.Pharmacies;
using Services_Layer.DTOS.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.Services.Branch_Services
{
    public interface IBranchServices
    {

        public List<BranchWithDistributorAndCountry> GetBranches();

        public List<BranchWithDistributorAndCountry> FillterByCountry(int country_id);

        public List<BranchWithDistributorAndCountry> FillterByDistrbutor(int dis_id);


        public List<BranchWithDistributorAndCountry> FillterByCountryAndDistributor(int dis_id, int country_id);


        public BranchWithDistributorAndCountry? GetByID(int id);


        public Branch Add(BranchDTO con);


        public bool Update(int id, UpdateBranchDTO con);


        public bool Remove(int ID);
    }
}
