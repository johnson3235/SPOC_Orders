using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.DTOS.Mail
{
    public class EmailRequestModel
    {
        public List<string> To { get; set; }
        public List<string>? Cc { get; set; }
        public List<string>? Bcc { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<string>? Attachments { get; set; }
    }

}
