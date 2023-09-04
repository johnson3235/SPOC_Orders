using DB_Layer.Models;
using Services_Layer.DTOS.Distributor;
using Services_Layer.DTOS.Pharmacies;
using Services_Layer.DTOS.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.Services.Role_Services
{
    public interface IRoleServices
    {

        public List<Role> GetRoles();



        public Role? GetByID(int id);



        public Role? Add(RoleDTO Role);



        public bool Update(int id, UpdateRoleDTO Role);

        public bool Remove(int Id);
    }
}
