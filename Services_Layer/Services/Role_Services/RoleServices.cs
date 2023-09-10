using AutoMapper;
using DB_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using Repo_Layer.Repositry;
using Repo_Layer.UnitOfWork;
using Services_Layer.DTOS.Distributor;
using Services_Layer.DTOS.Pharmacies;
using Services_Layer.DTOS.Products;
using Services_Layer.Response_Model;
using Services_Layer.Services.Product_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.Services.Role_Services
{
    public class RoleServices : Service<Role>, IRoleServices
    {
        private readonly IUnitOFWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoleServices(IUnitOFWork _unitofwork, IMapper _mapper) : base(_unitofwork, _mapper)
        {
            this._unitOfWork = _unitofwork;
            this._mapper = _mapper;
        }



        public GenericResponse<List<Role>> GetRoles()
        {
            List<Role> Role_list = _unitOfWork.Role_Repo.GetAll();
            var respose = new GenericResponse<List<Role>>() {Message= "Get Roles Successfully" ,Data = Role_list };
            return respose;
        }



        public GenericResponse<Role?> GetByID(int id)
        {
            Role phar = _unitOfWork.Role_Repo.Get(id);

            if (phar != null)
            {
                var respose = new GenericResponse<Role>() { Message = "Get Role Successfully", Data = phar };
                return respose;
            }
            else
            { return new GenericResponse<Role>() { Message = "Get Role Successfully", Data = null }; }

        }



        public GenericResponse<Role?> Add(RoleDTO Role)
        {
            Role con = _mapper.Map<Role>(Role);
            _unitOfWork.Role_Repo.Insert(con);
            try
            {
                int savedChanges = _unitOfWork.Save();

                if (savedChanges > 0)
                {
                    var respose = new GenericResponse<Role>() { Message = "Add Role Successfully", Data = con };
                    return respose;
                }
                else
                {
                    return new GenericResponse<Role>() { Message = "Add Role Failed", Data = null };
                }
            }
            catch (Exception ex)
            {
                return new GenericResponse<Role>() { Message = "Add Role Failed", Data = null };
            }

        }
           


        public GenericResponse<bool> Update(int id, UpdateRoleDTO Role)
        {

            if (id == Role.Id)
            {
                _unitOfWork.Role_Repo.Update(_mapper.Map<Role>(Role));
                _unitOfWork.Save();
                var res = new GenericResponse<bool>() { Message = "Add Role Successfully", Data = true };
                return res;

            }
            var response = new GenericResponse<bool>() { Message = "Add Role Failed", Data = false };
            return response;
        }


        public GenericResponse<bool> Remove(int Id)
        {
            var pro = _unitOfWork.Role_Repo.Get(Id);
            if (pro != null)
            {
                _unitOfWork.Role_Repo.Delete(Id);
                _unitOfWork.Save();
                var res = new GenericResponse<bool>() { Message = "Add Role Successfully", Data = true };
                return res;
            }
            var response = new GenericResponse<bool>() { Message = "Add Role Failed", Data = false };
            return response;

        }



    }
}
