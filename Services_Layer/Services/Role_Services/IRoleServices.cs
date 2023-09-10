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

namespace Services_Layer.Services.Role_Services
{
    public interface IRoleServices
    {



        public GenericResponse<List<Role>> GetRoles();



        public GenericResponse<Role>? GetByID(int id);



        public GenericResponse<Role>? Add(RoleDTO Role);



        public GenericResponse<bool> Update(int id, UpdateRoleDTO Role);


        public GenericResponse<bool> Remove(int Id);

    }
}
