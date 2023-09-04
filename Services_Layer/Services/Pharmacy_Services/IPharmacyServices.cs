using DB_Layer.Models;
using Services_Layer.DTOS.Pharmacies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.Services.Pharmacy_Services
{
    public interface IPharmacyServices
    {

        public List<GetPharmciesWithCountry> GetPharmacies();



        public GetPharmciesWithCountry? GetByID(int id);

        public List<GetPharmciesWithCountry> GetByCountry(int Country_id);

        public Pharmacy Add(AddPharmacyDTO pharmacy);


        public bool Update(int id, UpdatePharmacyDTO pharmacy);


        public bool Remove(int ID);
    }
}
