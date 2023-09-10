using DB_Layer.Models;
using Services_Layer.DTOS.Pharmacies;
using Services_Layer.Response_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.Services.Pharmacy_Services
{
    public interface IPharmacyServices
    {



        public GenericResponse<List<GetPharmciesWithCountry>> GetPharmacies();



        public GenericResponse<GetPharmciesWithCountry?> GetByID(int id);


        public GenericResponse<List<GetPharmciesWithCountry>> GetByCountry(int Country_id);


        public GenericResponse<Pharmacy?> Add(AddPharmacyDTO pharmacy);



        public GenericResponse<bool> Update(int id, UpdatePharmacyDTO pharmacy);


        public GenericResponse<bool> Remove(int ID);

    }
}
