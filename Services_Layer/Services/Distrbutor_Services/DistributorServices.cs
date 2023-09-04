using AutoMapper;
using DB_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using Repo_Layer.Repositry;
using Repo_Layer.UnitOfWork;
using Services_Layer.DTOS.Distributor;
using Services_Layer.DTOS.Pharmacies;
using Services_Layer.DTOS.Products;
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



        public List<Distributor> GetDistributors()
        {
            List<Distributor> country_list = _unitOfWork.Distributor_Repo.GetAll();
          
            return country_list;
        }



        public Distributor? GetByID(int id)
        {
            Distributor phar = _unitOfWork.Distributor_Repo.Get(id);
            
            if (phar != null)
            {
                return phar;
            }
            else
            { return null; }

        }



        public Distributor? Add(DistributorDTO Distributor)
        {
            Distributor con = _mapper.Map<Distributor>(Distributor);
            _unitOfWork.Distributor_Repo.Insert(con);
            try
            {
                int savedChanges = _unitOfWork.Save();

                if (savedChanges > 0)
                {
                    return con;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }
           


        public bool Update(int id, UpdateDistributorDTO Distributor)
        {


            if (id == Distributor.ID)
            {
                _unitOfWork.Distributor_Repo.Update(_mapper.Map<Distributor>(Distributor));
                _unitOfWork.Save();
                return true;
            }
            return false;
        }


        public bool Remove(int ID)
        {
            var pro = _unitOfWork.Distributor_Repo.Get(ID);
            if (pro != null)
            {
                _unitOfWork.Distributor_Repo.Delete(ID);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }



    }
}
