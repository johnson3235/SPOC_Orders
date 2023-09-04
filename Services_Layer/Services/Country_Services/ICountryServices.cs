using DB_Layer.Models;
using Services_Layer.DTOS.Pharmacies;
using Services_Layer.DTOS.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.Services.Country_Services
{
    public interface ICountryServices
    {

        public List<Country> GetCountries();



        public Country? GetByID(int id);


        public Country Add(CountryDTO con);


        public bool Update(int id, UpdateCountryDTO Country);


        public bool Remove(int ID);
    }
}
