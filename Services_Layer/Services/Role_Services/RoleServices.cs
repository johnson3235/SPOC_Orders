using AutoMapper;
using DB_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using Repo_Layer.Repositry;
using Repo_Layer.UnitOfWork;
using Services_Layer.DTOS.Distributor;
using Services_Layer.DTOS.Pharmacies;
using Services_Layer.DTOS.Products;
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



        public List<Role> GetRoles()
        {
            List<Role> Role_list = _unitOfWork.Role_Repo.GetAll();
          
            return Role_list;
        }



        public Role? GetByID(int id)
        {
            Role phar = _unitOfWork.Role_Repo.Get(id);
            
            if (phar != null)
            {
                return phar;
            }
            else
            { return null; }

        }



        public Role? Add(RoleDTO Role)
        {
            Role con = _mapper.Map<Role>(Role);
            _unitOfWork.Role_Repo.Insert(con);
            try
            {
                int savedChanges = _unitOfWork.Save();

                if (savedChanges > 0)
                {
                    return con;
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
           


        public bool Update(int id, UpdateRoleDTO Role)
        {


            if (id == Role.Id)
            {
                _unitOfWork.Role_Repo.Update(_mapper.Map<Role>(Role));
                _unitOfWork.Save();
                return true;
            }
            return false;
        }


        public bool Remove(int Id)
        {
            var pro = _unitOfWork.Role_Repo.Get(Id);
            if (pro != null)
            {
                _unitOfWork.Role_Repo.Delete(Id);
                _unitOfWork.Save();
                return true;
            }
            return false;

        }



    }
}
