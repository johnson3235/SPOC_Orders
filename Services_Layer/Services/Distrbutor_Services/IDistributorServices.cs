using DB_Layer.Models;
using Services_Layer.DTOS.Distributor;
using Services_Layer.DTOS.Pharmacies;
using Services_Layer.DTOS.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.Services.Distributor_Services
{
    public interface IDistributorServices
    {

        public List<Distributor> GetDistributors();



        public Distributor? GetByID(int id);


        public Distributor Add(DistributorDTO con);


        public bool Update(int id, UpdateDistributorDTO Distributor);


        public bool Remove(int ID);
    }
}
