using DB_Layer.Models;
using Services_Layer.DTOS.Branches;
using Services_Layer.DTOS.Pharmacies;
using Services_Layer.DTOS.Products;
using Services_Layer.Response_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.Services.Branch_Services
{
    public interface IBranchServices
    {

        public GenericResponse<List<BranchWithDistributorAndCountry>> GetBranches();

        public GenericResponse<List<BranchWithDistributorAndCountry>> FillterByCountry(int country_id);


        public GenericResponse<List<BranchWithDistributorAndCountry>> FillterByDistrbutor(int dis_id);



        public GenericResponse<List<BranchWithDistributorAndCountry>> FillterByCountryAndDistributor(int dis_id, int country_id);



        public GenericResponse<BranchWithDistributorAndCountry?> GetByID(int id);



        public GenericResponse<Branch?> Add(BranchDTO Branch);



        public GenericResponse<bool> Update(int id, UpdateBranchDTO Branch);


        public GenericResponse<bool> Remove(int ID);

    }
}
