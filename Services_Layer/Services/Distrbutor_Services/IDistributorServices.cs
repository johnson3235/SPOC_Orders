using DB_Layer.Models;
using Services_Layer.DTOS.Distributor;
using Services_Layer.DTOS.Pharmacies;
using Services_Layer.DTOS.Products;
using Services_Layer.Response_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.Services.Distributor_Services
{
    public interface IDistributorServices
    {


        public GenericResponse<List<Distributor>> GetDistributors();


        public GenericResponse<Distributor?> GetByID(int id);



        public GenericResponse<Distributor?> Add(DistributorDTO Distributor);



        public GenericResponse<bool> Update(int id, UpdateDistributorDTO Distributor);


        public GenericResponse<bool> Remove(int ID);

    }
}
