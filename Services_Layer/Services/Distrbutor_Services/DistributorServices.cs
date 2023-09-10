using AutoMapper;
using DB_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using Repo_Layer.Repositry;
using Repo_Layer.UnitOfWork;
using Services_Layer.DTOS.Distributor;
using Services_Layer.DTOS.Pharmacies;
using Services_Layer.DTOS.Products;
using Services_Layer.Response_Model;
using Services_Layer.Services.Product_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.Services.Distributor_Services
{
    public class DistributorServices : Service<Distributor>, IDistributorServices
    {
        private readonly IUnitOFWork _unitOfWork;
        private readonly IMapper _mapper;

        public DistributorServices(IUnitOFWork _unitofwork, IMapper _mapper) : base(_unitofwork, _mapper)
        {
            this._unitOfWork = _unitofwork;
            this._mapper = _mapper;
        }



        public GenericResponse<List<Distributor>> GetDistributors()
        {
            var country_list = _unitOfWork.Distributor_Repo.GetAll();
            GenericResponse<List<Distributor>> Dis_List = new GenericResponse<List<Distributor>>()
            {
                Data = country_list,
                Message = "Get Distributors Successfully"
            };

            return Dis_List;
        }



        public GenericResponse<Distributor?> GetByID(int id)
        {
            Distributor phar = _unitOfWork.Distributor_Repo.Get(id);
           
            if (phar != null)
            {
                GenericResponse<Distributor> dis = new GenericResponse<Distributor>() { Data = phar, Message = "Get Distributor Successfully" };
                return dis;
            }
            else
            {
                GenericResponse<Distributor> dis = new GenericResponse<Distributor>() { Data = null, Message = "Get Distributor Successfully" };
                return dis; 
            }

        }



        public GenericResponse<Distributor?> Add(DistributorDTO Distributor)
        {
            Distributor con = _mapper.Map<Distributor>(Distributor);
            _unitOfWork.Distributor_Repo.Insert(con);
            try
            {
                int savedChanges = _unitOfWork.Save();

                if (savedChanges > 0)
                {
                    GenericResponse<Distributor> dis = new GenericResponse<Distributor>() { Data = con, Message = "Get Distributor Successfully" };
                    return dis;
                }
                else
                {
                    GenericResponse<Distributor> dis = new GenericResponse<Distributor>() { Data = null, Message = "Get Distributor Successfully" };
                    return dis;
                }
            }
            catch (Exception ex)
            {
                GenericResponse<Distributor> dis = new GenericResponse<Distributor>() { Data = null, Message = "Get Distributor Successfully" };
                return dis;
            }

        }
           


        public GenericResponse<bool> Update(int id, UpdateDistributorDTO Distributor)
        {


            if (id == Distributor.ID)
            {
                _unitOfWork.Distributor_Repo.Update(_mapper.Map<Distributor>(Distributor));
                _unitOfWork.Save();
                var res = new GenericResponse<bool>() { Message = "Deleted Distributor Successfully", Data = true };
                return res;

            }
            var response = new GenericResponse<bool>() { Message = "Delete Distributor Failed", Data = false };
            return response;
        }


        public GenericResponse<bool> Remove(int ID)
        {
            var pro = _unitOfWork.Distributor_Repo.Get(ID);
            if (pro != null)
            {
                _unitOfWork.Distributor_Repo.Delete(ID);
                _unitOfWork.Save();
                var res = new GenericResponse<bool>() { Message = "Deleted Distributor Successfully", Data = true };
                return res;

            }
            var response = new GenericResponse<bool>() { Message = "Delete Distributor Failed", Data = false };
            return response;
        }



    }
}
