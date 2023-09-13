using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.Services.Email_Services
{
    using System;
    using System.Net;
    using System.Net.Mail;
    using Microsoft.Extensions.Configuration;

    public class EmailService : IEmailService
    {

        //public  bool SendEmail(string to, string subject, string body)
        //{
        //    var smtpClient = new SmtpClient
        //    {
        //        Host = "smtp.gmail.com",
        //        Port = 587,
        //        EnableSsl = true,
        //        Credentials = new NetworkCredential("i.carcomminty@gmail.com", "gxgmuepgtdpkcndh")
        //    };

        //    var mailMessage = new MailMessage
        //    {
        //        From = new MailAddress("i.carcomminty@gmail.com"),
        //        Subject = subject,
        //        Body = body,
        //        IsBodyHtml = false
        //    };

        //    mailMessage.To.Add(new MailAddress(to));
        //    try { 
        //    smtpClient.Send(mailMessage);
        //        return true;
        //    }
        //    catch(Exception ex)
        //    {
        //        return false;
        //    }
        //}


        public bool SendEmail(List<string> toList, string subject, string body, List<string> ccList = null, List<string> bccList = null, List<string> attachments = null)
        {
            var smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential("i.carcommunity@gmail.com", "gxgmuepgtdpkcndh")
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("i.carcommunity@gmail.com"),
                Subject = subject,
                Body = body,
                IsBodyHtml = false
            };

            foreach (var to in toList)
            {
                mailMessage.To.Add(new MailAddress(to));
            }

            if (ccList != null && ccList.Any())
            {
                foreach (var cc in ccList)
                {
                    mailMessage.CC.Add(new MailAddress(cc));
                }
            }

            if (bccList != null && bccList.Any())
            {
                foreach (var bcc in bccList)
                {
                    mailMessage.Bcc.Add(new MailAddress(bcc));
                }
            }

            if (attachments != null && attachments.Any())
            {
                foreach (var attachmentPath in attachments)
                {
                    if (File.Exists(attachmentPath))
                    {
                        var attachment = new Attachment(attachmentPath);
                        mailMessage.Attachments.Add(attachment);
                    }
                }
            }

            try
            {
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                // Handle exceptions or log them as needed
                return false;
            }
        }



    }
}
