using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.Services.Email_Services
{
    public interface IEmailService
    {
       // public bool SendEmail(string to, string subject, string body);

        public bool SendEmail(List<string> toList, string subject, string body, List<string> ccList = null, List<string> bccList = null, List<string> attachments = null);
        //public  Task SendEmail(string to, string subject, string body);
    }
}
