using AutoMapper;
using DB_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using Repo_Layer.Repositry;
using Repo_Layer.UnitOfWork;
using Services_Layer.DTOS.Pharmacies;
using Services_Layer.Services.Product_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.Services.Pharmacy_Services
{
    public class PharmacyServices : Service<Pharmacy>, IPharmacyServices
    {
        private readonly IUnitOFWork _unitOfWork;
        private readonly IMapper _mapper;

        public PharmacyServices(IUnitOFWork _unitofwork, IMapper _mapper) : base(_unitofwork, _mapper)
        {
            this._unitOfWork = _unitofwork;
            this._mapper = _mapper;
        }



        public List<GetPharmciesWithCountry> GetPharmacies()
        {
            List<Pharmacy> phr_list = _unitOfWork.Pharmacy_Repo.GetAll("Country");
            List<GetPharmciesWithCountry> pharmacyDtos = new List<GetPharmciesWithCountry>();
            foreach (var phr in phr_list)
            {
                pharmacyDtos.Add(_mapper.Map<GetPharmciesWithCountry>(phr));
            }
          
            return pharmacyDtos;
        }



        public GetPharmciesWithCountry? GetByID(int id)
        {
            Pharmacy phar = _unitOfWork.Pharmacy_Repo.Get(id);
            
            if (phar != null)
            {
                
                if (phar.ConId != 0 || phar.ConId != null)
                {
                    phar.Country = _unitOfWork.Country_Repo.Get(phar.ConId);
                }

                GetPharmciesWithCountry DTO_Pharmacy = _mapper.Map<GetPharmciesWithCountry>(phar);
                return DTO_Pharmacy;
            }
            else
            { return null; }

        }


        public List<GetPharmciesWithCountry> GetByCountry(int Country_id)
        {
            List<Pharmacy> phar_list = _unitOfWork.Pharmacy_Repo.FillterByCountry(Country_id);

            List<GetPharmciesWithCountry> pharmacyDtos = new List<GetPharmciesWithCountry>();
            foreach (var phr in phar_list)
            {
                pharmacyDtos.Add(_mapper.Map<GetPharmciesWithCountry>(phr));
            }

            return pharmacyDtos;

        }


        public Pharmacy? Add(AddPharmacyDTO pharmacy)
        {
            Pharmacy New_Pharmacy = _mapper.Map<Pharmacy>(pharmacy);

            _unitOfWork.Pharmacy_Repo.Insert(New_Pharmacy);
            try
            {
                int savedChanges = _unitOfWork.Save();

                if (savedChanges > 0)
                {
                    return New_Pharmacy;
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
           


        public bool Update(int id, UpdatePharmacyDTO pharmacy)
        {
            Pharmacy New_Pharmacy = _mapper.Map<Pharmacy>(pharmacy);

            if (id == New_Pharmacy.Id)
            {
                _unitOfWork.Pharmacy_Repo.Update(New_Pharmacy);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }


        public bool Remove(int ID)
        {
            var pro = _unitOfWork.Pharmacy_Repo.Get(ID);
            if (pro != null)
            {
                _unitOfWork.Pharmacy_Repo.Delete(ID);
                _unitOfWork.Save();
                return true;
            }
            return false;

        }


        public bool DoesCountryExist(int countryId)
        {
            var country = _unitOfWork.Country_Repo.Get(countryId); // Replace with your actual repository method
            return country != null;
        }

    }
}
