using AutoMapper;
using DB_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using Repo_Layer.Repositry;
using Repo_Layer.UnitOfWork;
using Services_Layer.DTOS.Pharmacies;
using Services_Layer.DTOS.Products;
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



        public List<Country> GetCountries()
        {

            List<Country> country_list = _unitOfWork.Country_Repo.GetAll();
          
            return country_list;
        }



        public Country? GetByID(int id)
        {
            Country phar = _unitOfWork.Country_Repo.Get(id);
            
            if (phar != null)
            {
                return phar;
            }
            else
            { return null; }

        }



        public Country? Add(CountryDTO Country)
        {
            Country con = _mapper.Map<Country>(Country);
            _unitOfWork.Country_Repo.Insert(con);
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
           


        public bool Update(int id, UpdateCountryDTO Country)
        {


            if (id == Country.Id)
            {
                _unitOfWork.Country_Repo.Update(_mapper.Map<Country>(Country));
                _unitOfWork.Save();
                return true;
            }
            return false;
        }


        public bool Remove(int ID)
        {
            var pro = _unitOfWork.Country_Repo.Get(ID);
            if (pro != null)
            {
                _unitOfWork.Country_Repo.Delete(ID);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }



    }
}
