using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.Services.Email_Services
{

    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
