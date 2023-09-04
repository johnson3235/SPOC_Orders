using DB_Layer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services_Layer.DTOS.Distributor;
using Services_Layer.DTOS.Pharmacies;
using Services_Layer.DTOS.Products;
using Services_Layer.DTOS.User;
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

        public  Task<bool> Register(RegisiterDTO newUserDto);

        public  Task<tokenDTO> Login
            (LoginDTO newUser, [FromServices] IConfiguration config);

        public Task<bool> ResetPassword(ResetPasswordDTO resetPasswordDto);

        public  Task<List<UserDTO>> GetAllUsers();

        public  Task<UserDTO> GetUserById(int id);


        public  Task<List<UserDTO>> FillterByRole(int role_id);

        public  Task<List<UserDTO>> GetAllDM();

        public  Task<List<UserDTO>> GetAllMedRep();


    }
}
