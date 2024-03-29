﻿using AutoMapper;
using DB_Layer.Models;
using Repo_Layer.UnitOfWork;
using Services_Layer.DTOS.Branches;
using Services_Layer.DTOS.Pharmacies;
using Services_Layer.DTOS.Products;
using Services_Layer.Response_Model;
using Services_Layer.Services.Country_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.Services.Branch_Services
{
    public class BranchServices : Service<Branch>, IBranchServices
    {
        private readonly IUnitOFWork _unitOfWork;
        private readonly IMapper _mapper;

        public BranchServices(IUnitOFWork _unitofwork, IMapper _mapper) : base(_unitofwork, _mapper)
        {
            this._unitOfWork = _unitofwork;
            this._mapper = _mapper;
        }



        public GenericResponse<List<BranchWithDistributorAndCountry>>  GetBranches()
        {
            List<Branch> Branch_List = _unitOfWork.Branch_Repo.GetBranchesWithDistributorAndCountry();


            List<BranchWithDistributorAndCountry> Branch_Dtos = new List<BranchWithDistributorAndCountry>();
            foreach (var phr in Branch_List)
            {
                Branch_Dtos.Add(_mapper.Map<BranchWithDistributorAndCountry>(phr));
            }


            return new GenericResponse<List<BranchWithDistributorAndCountry>>() { Data = Branch_Dtos, Message = "Get Branches Successfully" };
        }


        public GenericResponse<List<BranchWithDistributorAndCountry>> FillterByCountry(int country_id)
        {
            List<Branch> Branch_List = _unitOfWork.Branch_Repo.FillterByCountry(country_id);


            List<BranchWithDistributorAndCountry> Branch_Dtos = new List<BranchWithDistributorAndCountry>();
            foreach (var phr in Branch_List)
            {
                Branch_Dtos.Add(_mapper.Map<BranchWithDistributorAndCountry>(phr));
            }

            return new GenericResponse<List<BranchWithDistributorAndCountry>>() { Data = Branch_Dtos, Message = "Get Branches Successfully" }; 
        }


        public GenericResponse<List<BranchWithDistributorAndCountry>> FillterByDistrbutor(int dis_id)
        {
            List<Branch> Branch_List = _unitOfWork.Branch_Repo.FillterByDistributor(dis_id);


            List<BranchWithDistributorAndCountry> Branch_Dtos = new List<BranchWithDistributorAndCountry>();
            foreach (var phr in Branch_List)
            {
                Branch_Dtos.Add(_mapper.Map<BranchWithDistributorAndCountry>(phr));
            }

            return new GenericResponse<List<BranchWithDistributorAndCountry>>() { Data = Branch_Dtos, Message = "Get Branches Successfully" };
        }



        public GenericResponse<List<BranchWithDistributorAndCountry>> FillterByCountryAndDistributor(int dis_id,int country_id)
        {
            List<Branch> Branch_List = _unitOfWork.Branch_Repo.FillterByDistributorAndCountry(dis_id, country_id);


            List<BranchWithDistributorAndCountry> Branch_Dtos = new List<BranchWithDistributorAndCountry>();
            foreach (var phr in Branch_List)
            {
                Branch_Dtos.Add(_mapper.Map<BranchWithDistributorAndCountry>(phr));
            }

            return new GenericResponse<List<BranchWithDistributorAndCountry>>() { Data = Branch_Dtos, Message = "Get Branches Successfully" };
        }



        public GenericResponse<BranchWithDistributorAndCountry?> GetByID(int id)
        {
            Branch phar = _unitOfWork.Branch_Repo.Get(id);

            if (phar != null)
            {
                BranchWithDistributorAndCountry Branch_Dtos = _mapper.Map<BranchWithDistributorAndCountry>(phar);
                GenericResponse<BranchWithDistributorAndCountry?> res = new GenericResponse<BranchWithDistributorAndCountry?>() { Data = Branch_Dtos, Message = "Get Branch Successfully" };
                return res;
            }
            else
            { return new GenericResponse<BranchWithDistributorAndCountry?>() { Data = null, Message = "Get Branch Successfully" }; }

        }



        public GenericResponse<Branch?> Add(BranchDTO Branch)
        {
            Branch con = _mapper.Map<Branch>(Branch);
            _unitOfWork.Branch_Repo.Insert(con);
            try
            {
                int savedChanges = _unitOfWork.Save();

                if (savedChanges > 0)
                {
                    return new GenericResponse<Branch?>() { Data = con, Message = "Added Branch Successfully" };
                }
                else
                {
                    return new GenericResponse<Branch?>() { Data = null, Message = "Added Branch Failed" };
                }
            }
            catch (Exception ex)
            {
                return new GenericResponse<Branch?>() { Data = null, Message = "Added Branch Failed Exception" };
            }

        }



        public GenericResponse<bool> Update(int id, UpdateBranchDTO Branch)
        {
            Branch con = _mapper.Map<Branch>(Branch);

            if (id == con.Id)
            {
                _unitOfWork.Branch_Repo.Update(con);
                _unitOfWork.Save();
                var res = new GenericResponse<bool>() { Message = "Updated Branch Successfully", Data = true };
                return res;

            }
            var response = new GenericResponse<bool>() { Message = "Updated Branch Failed", Data = false };
            return response;
        }


        public GenericResponse<bool> Remove(int ID)
        {
            var pro = _unitOfWork.Branch_Repo.Get(ID);
            if (pro != null)
            {
                _unitOfWork.Branch_Repo.Delete(ID);
                _unitOfWork.Save();
                var res = new GenericResponse<bool>() { Message = "Deleted Branch Successfully", Data = true };
                return res;

            }
            var response = new GenericResponse<bool>() { Message = "Deleted Branch Failed", Data = false };
            return response;
        }



    }
}
