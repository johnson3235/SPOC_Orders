using MailKit;
using Microsoft.AspNetCore.Mvc;
using Services_Layer.DTOS.Mail;
using Services_Layer.Services.Email_Services;

namespace SPOC_Orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public MailController(IEmailService emailService)
        {
            _emailService = emailService;
        }


        [HttpPost("send")]
        public async Task<IActionResult> SendEmail([FromBody] EmailRequestModel emailRequest)
        {
            if (emailRequest == null)
            {
                return BadRequest("Invalid email request");
            }

            var complete =  _emailService.SendEmail(emailRequest.To, emailRequest.Subject, emailRequest.Body, emailRequest.Cc, emailRequest.Bcc, emailRequest.Attachments);

            if(complete)
                {
                return Ok("Email sent successfully");
            }
            return BadRequest("Failed Send Mail");
        }






        //private readonly Services_Layer.Services.Email_Services.IMailService mailService;
        //public MailController(Services_Layer.Services.Email_Services.IMailService mailService)
        //{
        //    this.mailService = mailService;
        //}
        //[HttpPost("send")]
        //public async Task<IActionResult> SendMail([FromForm] MailRequest request)
        //{
        //    try
        //    {
        //        await mailService.SendEmailAsync(request);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }

        //}
    }
}
