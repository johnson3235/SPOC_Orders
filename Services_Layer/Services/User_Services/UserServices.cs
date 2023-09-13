using AutoMapper;
using DB_Layer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repo_Layer.Repositry;
using Repo_Layer.UnitOfWork;
using Services_Layer.DTOS.Distributor;
using Services_Layer.DTOS.Pharmacies;
using Services_Layer.DTOS.Products;
using Services_Layer.DTOS.User;
using Services_Layer.Response_Model;
using Services_Layer.Services.Product_Services;
using Services_Layer.Services.User_Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.Services.User_Services
{
    public class UserServices : Service<Role>, IUserServices
    {
        private readonly IUnitOFWork _unitOfWork;
        private readonly IMapper _mapper;



        public UserServices(IUnitOFWork _unitofwork, IMapper _mapper) : base(_unitofwork, _mapper)
        {
            this._unitOfWork = _unitofwork;
            this._mapper = _mapper;
       
        }

        public async Task<GenericResponse<List<UserDTO>>> GetAllUsers()
        {
            List<CustomUser> users = await _unitOfWork.User_Repo.Users.ToListAsync();
            List<UserDTO> users_list = new List<UserDTO>();
            foreach(var user in users)
            {
                users_list.Add(new UserDTO() { Id = user.Id , userName = user.UserName , Manager = user.Manager});
            }
           
           
            return new GenericResponse<List<UserDTO>>() { Data = users_list , Message ="Get Users Successfully"};
        }

        public async Task<GenericResponse<UserDTO?>> GetUserById(int id)
        {
            CustomUser user = await _unitOfWork.User_Repo.FindByIdAsync(id.ToString());
            if(user != null)
            {
                UserDTO user_Dto = new UserDTO() { Id = user.Id, userName = user.UserName, Manager = user.Manager };

                return new GenericResponse<UserDTO>() { Data = user_Dto, Message = "Get Users Successfully" }; 
            }
            return new GenericResponse<UserDTO>() { Data = null, Message = "Get Users Failed" };

        }


        public async Task<GenericResponse<List<UserDTO>>> FillterByRole(int role_id)
        {
            List<CustomUser> users = await _unitOfWork.User_Repo.Users.Where(u=>u.RoleId == role_id).ToListAsync();
            List<UserDTO> users_list = new List<UserDTO>();
            foreach (var user in users)
            {
                users_list.Add(new UserDTO() { Id = user.Id, userName = user.UserName, Manager = user.Manager });
            }


            return new GenericResponse<List<UserDTO>>() { Data = users_list, Message = "Get Users Successfully" };
        }

        public async Task<GenericResponse<List<UserDTO>>> GetAllDM()
        {
            List<CustomUser> users = await _unitOfWork.User_Repo.Users.Where(c=>c.RoleId == 1).ToListAsync();
            List<UserDTO> users_list = new List<UserDTO>();
            foreach (var user in users)
            {
                users_list.Add(new UserDTO() { Id = user.Id, userName = user.UserName, Manager = user.Manager });
            }


            return new GenericResponse<List<UserDTO>>() { Data = users_list, Message = "Get Users Successfully" }; 
        }

        public async Task<GenericResponse<List<UserDTO>>> GetAllMedRep()
        {
            List<CustomUser> users = await _unitOfWork.User_Repo.Users.Where(c => c.RoleId == 2).ToListAsync();
            List<UserDTO> users_list = new List<UserDTO>();
            foreach (var user in users)
            {
                users_list.Add(new UserDTO() { Id = user.Id, userName = user.UserName, Manager = user.Manager });
            }
            return new GenericResponse<List<UserDTO>>() { Data = users_list, Message = "Get Users Successfully" };
        }


        public async Task<GenericResponse<bool>> Register(RegisiterDTO newUserDto)
        {
            CustomUser appUser = new CustomUser();
            appUser.UserName = newUserDto.userName;
            appUser.Email = newUserDto.Email;
            appUser.PasswordHash = newUserDto.Password;
            appUser.RoleId = newUserDto.RoleId;

            IdentityResult result =
                await _unitOfWork.User_Repo.CreateAsync(appUser, appUser.PasswordHash);
            if (result.Succeeded)
                return new GenericResponse<bool>() { Data = true, Message = "User Created Successfully" }; 
            else
                return new GenericResponse<bool>() { Data = false, Message = "User Created Failed" };

        }

        public async Task<GenericResponse<tokenDTO?>> Login
            (LoginDTO newUser, [FromServices] IConfiguration config)
        {
            //check
            CustomUser appUserModel =
              await _unitOfWork.User_Repo.FindByNameAsync(newUser.userName);
            if (appUserModel != null)
            {
                bool found = await _unitOfWork.User_Repo.CheckPasswordAsync(appUserModel, newUser.Password);
                if (found)
                {





                    ////userManager.GetRolesAsync(appUserModel);
                    //List<Claim> claims = new List<Claim>();
                    //claims.Add(new Claim(ClaimTypes.Name, newUser.userName));
                    //claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                    ////claims.Add(new Claim(ClaimTypes.Role,));

                    //var symKey =
                    //    new SymmetricSecurityKey(
                    //        Encoding.UTF8.GetBytes(config["JWT:Key"]));

                    //var signInCredentials = new SigningCredentials
                    //    (symKey, SecurityAlgorithms.HmacSha256);


                    //JwtSecurityToken UserToken = new JwtSecurityToken(
                    //    issuer: config["JWT:Issues"],
                    //    audience: config["JWT:Audiance"],
                    //    expires: DateTime.Now.AddHours(1),
                    //    claims: claims,
                    //    signingCredentials: signInCredentials
                    //    );
                    //var token = new tokenDTO() { token = new JwtSecurityTokenHandler().WriteToken(UserToken), expired_date = UserToken.ValidTo };

                    return new GenericResponse<tokenDTO>() { Data = null, Message = "User Login Successfully" };

                }
            }

            return new GenericResponse<tokenDTO>() { Data = null, Message = "User Login Failed" };
        }



        public async Task<GenericResponse<bool>> ResetPassword(ResetPasswordDTO resetPasswordDto)
        {
            // Find the user by username (you can modify this to use email or other identifiers)
            CustomUser user = await _unitOfWork.User_Repo.FindByNameAsync(resetPasswordDto.UserName);
            if (user != null)
            {
                bool found = await _unitOfWork.User_Repo.CheckPasswordAsync(user, resetPasswordDto.OldPassword);
                if (found)
                {
                    string resetToken = await _unitOfWork.User_Repo.GeneratePasswordResetTokenAsync(user);
                    IdentityResult result = await _unitOfWork.User_Repo.ResetPasswordAsync(user, resetToken, resetPasswordDto.NewPassword);

                    if (result.Succeeded)
                    {
                        return new GenericResponse<bool>() { Data = true, Message = "User Reset Password Successfully" };
                    }
                    else
                    {
                          return new GenericResponse<bool>() { Data = false, Message = "User Reset Password Failed" };
                    }
                }
                return new GenericResponse<bool>() { Data = false, Message = "User Reset Password Failed" };
            }
            return new GenericResponse<bool>() { Data = false, Message = "User Reset Password Failed" };
        }
    }
}
