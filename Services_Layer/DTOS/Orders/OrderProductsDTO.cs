using Services_Layer.Custom_Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.DTOS.Orders
{
    public class OrderProductsDTO
    {
        [ExistsProperty(ValidationModel.Product)]
        public int ProductId { get; set; }

        [Required,Range(1,99999)]
        public int quantity { get; set; }

        [Required, Range(1, 99999999)]
        public float totalprice { get; set; }

    }
}
