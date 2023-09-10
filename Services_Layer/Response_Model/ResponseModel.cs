using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.Response_Model
{
    public class ResponseModel
    {
            public  ResponseModel()
            {
                ErrorList = new List<ErrorListModel>();
                Message = "";
            }

            public string Message { get; set; }

            public List<ErrorListModel> ErrorList { get; set; }
    }
    

        public class ErrorListModel
        {
            public int Id { get; set; }
            public string Message { get; set; }
        }


    
}
