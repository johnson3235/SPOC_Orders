using DB_Layer.Models;
using Services_Layer.DTOS.Pharmacies;
using Services_Layer.DTOS.Products;
using Services_Layer.Response_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.Services.Country_Services
{
    public interface ICountryServices
    {
        public GenericResponse<List<Country>> GetCountries();


        public GenericResponse<Country?> GetByID(int id);



        public GenericResponse<Country?> Add(CountryDTO Country);



        public GenericResponse<bool> Update(int id, UpdateCountryDTO Country);


        public GenericResponse<bool> Remove(int ID);

    }
}
