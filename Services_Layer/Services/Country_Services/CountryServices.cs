using AutoMapper;
using DB_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using Repo_Layer.Repositry;
using Repo_Layer.UnitOfWork;
using Services_Layer.DTOS.Pharmacies;
using Services_Layer.DTOS.Products;
using Services_Layer.Response_Model;
using Services_Layer.Services.Product_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.Services.Country_Services
{
    public class CountryServices : Service<Country>, ICountryServices
    {
        private readonly IUnitOFWork _unitOfWork;
        private readonly IMapper _mapper;

        public CountryServices(IUnitOFWork _unitofwork, IMapper _mapper) : base(_unitofwork, _mapper)
        {
            this._unitOfWork = _unitofwork;
            this._mapper = _mapper;
        }



        public GenericResponse<List<Country>> GetCountries()
        {

            List<Country> country_list = _unitOfWork.Country_Repo.GetAll();
            GenericResponse<List<Country>> coun = new GenericResponse<List<Country>>() { Data = country_list, Message = "Get Countries Successfully" };
            return coun;
        }



        public GenericResponse<Country?> GetByID(int id)
        {
            Country phar = _unitOfWork.Country_Repo.Get(id);
            
            if (phar != null)
            {
                GenericResponse<Country?> res = new GenericResponse<Country?>() { Data = phar, Message = "Get Country Successfully" };
                return res;
            }
            else
            {
                GenericResponse<Country?> res = new GenericResponse<Country?>() { Data = null, Message = "Get Country Failed" };
                return res;
            }

        }



        public GenericResponse<Country?> Add(CountryDTO Country)
        {
            Country con = _mapper.Map<Country>(Country);
            _unitOfWork.Country_Repo.Insert(con);
            try
            {
                int savedChanges = _unitOfWork.Save();

                if (savedChanges > 0)
                {
                    return new GenericResponse<Country?>() { Data = con, Message = "Added Country Successfully" };
                }
                else
                {
                    return new GenericResponse<Country?>() { Data = null, Message = "Added Country Failed" };
                }
            }
            catch (Exception ex)
            {
                return new GenericResponse<Country?>() { Data = null, Message = "Added Country Failed Exception" };
            }

        }
           


        public GenericResponse<bool> Update(int id, UpdateCountryDTO Country)
        {


            if (id == Country.Id)
            {
                _unitOfWork.Country_Repo.Update(_mapper.Map<Country>(Country));
                _unitOfWork.Save();
                var res = new GenericResponse<bool>() { Message = "Updated Country Successfully", Data = true };
                return res;

            }
            var response = new GenericResponse<bool>() { Message = "Updated Country Failed", Data = false };
            return response;
        }


        public GenericResponse<bool> Remove(int ID)
        {
            var pro = _unitOfWork.Country_Repo.Get(ID);
            if (pro != null)
            {
                _unitOfWork.Country_Repo.Delete(ID);
                _unitOfWork.Save();
                var res = new GenericResponse<bool>() { Message = "Deleted Country Successfully", Data = true };
                return res;

            }
            var response = new GenericResponse<bool>() { Message = "Delete Country Failed", Data = false };
            return response;
        }



    }
}
