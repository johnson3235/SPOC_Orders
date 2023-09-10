using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.Response_Model
{
    public class GenericResponse<TResult> : ResponseModel
    {

            public GenericResponse()
            {
                Type t = typeof(TResult);
                if (t.GetConstructor(Type.EmptyTypes) != null)
                    Data = Activator.CreateInstance<TResult>();
            }

            public TResult Data { get; set; }

        
    }
}
