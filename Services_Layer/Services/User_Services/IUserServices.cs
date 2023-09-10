using DB_Layer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services_Layer.DTOS.Distributor;
using Services_Layer.DTOS.Pharmacies;
using Services_Layer.DTOS.Products;
using Services_Layer.DTOS.User;
using Services_Layer.Response_Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.Services.User_Services
{
    public interface IUserServices
    {

        public  Task<GenericResponse<List<UserDTO>>> GetAllUsers();

        public  Task<GenericResponse<UserDTO?>> GetUserById(int id);


        public  Task<GenericResponse<List<UserDTO>>> FillterByRole(int role_id);

        public  Task<GenericResponse<List<UserDTO>>> GetAllDM();
        public  Task<GenericResponse<List<UserDTO>>> GetAllMedRep();


        public  Task<GenericResponse<bool>> Register(RegisiterDTO newUserDto);

        public  Task<GenericResponse<tokenDTO?>> Login
            (LoginDTO newUser, [FromServices] IConfiguration config);



        public  Task<GenericResponse<bool>> ResetPassword(ResetPasswordDTO resetPasswordDto);


    }
}
