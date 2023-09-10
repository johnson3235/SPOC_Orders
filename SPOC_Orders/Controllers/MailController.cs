using MailKit;
using Microsoft.AspNetCore.Mvc;
using Services_Layer.Services.Email_Services;

namespace SPOC_Orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly Services_Layer.Services.Email_Services.IMailService mailService;
        public MailController(Services_Layer.Services.Email_Services.IMailService mailService)
        {
            this.mailService = mailService;
        }
        [HttpPost("send")]
        public async Task<IActionResult> SendMail([FromForm] MailRequest request)
        {
            try
            {
                await mailService.SendEmailAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
