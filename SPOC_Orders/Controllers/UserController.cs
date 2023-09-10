using DB_Layer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services_Layer.DTOS.User;
using Services_Layer.Services.MicrosoftGraphHelper;
using Services_Layer.Services.User_Services;

namespace SPOC_Orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserServices User_services;
        private readonly IMicrosoftGraphHelper Login_Services;
        public UserController(IUserServices User_services, IMicrosoftGraphHelper Login_Services)
        {
            this.User_services = User_services;
            this.Login_Services = Login_Services;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await User_services.GetAllUsers();
            return Ok(users);
        }


        [HttpGet("DM")]
        public async Task<IActionResult> GetAllDM()
        {
            var users = await User_services.GetAllDM();
            return Ok(users);
        }



        [HttpGet("MedRep")]
        public async Task<IActionResult> GetAllMedRep()
        {
            var users = await User_services.GetAllMedRep();
            return Ok(users);
        }


        [HttpGet("Get/User/{id:int}")]
        // [Authorize]
        public async Task<ActionResult> GetByID(int id)
        {
            var con = await User_services.GetUserById(id);
            if (con.Data != null)
            {
                return Ok(con);
            }
            else
            { return BadRequest("Invalid Id"); }

        }


        [HttpGet("Fillter/User/{Roleid:int}")]
        // [Authorize]
        public async Task<ActionResult> FillterByRole(int Roleid)
        {
            var con = await User_services.FillterByRole(Roleid);

            return Ok(con);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDTO newUser, [FromServices] IConfiguration config)
        {
           var token = await User_services.Login(newUser, config);
            if(token.Data != null)
            { return Ok(token); }
             return BadRequest("Invalid User Data");
            
        }

        [HttpPost("register-user")]
        public async Task<ActionResult> Register(RegisiterDTO newUser)
        {
            var token = await User_services.Register(newUser);
            if (token.Data)
            { return Ok("User Created Success"); }
            return BadRequest("Invalid User Data");

        }


        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDTO resetPasswordDto)
        {
            var complete = await User_services.ResetPassword(resetPasswordDto);

            if (complete.Data)
            {
                return Ok("Password reset successful.");
            }
            else
            {
                return BadRequest("Password reset failed.");
            }
        }

        [HttpPost("o2login")]
        public async Task<IActionResult> Login(LoginDTO  data)
        {
           var token =  Login_Services.AcquireATokenFromUsernamePasswordAsync(data.userName, data.Password);
            return Ok(token);
        }


    }
}
