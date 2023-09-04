using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB_Layer.Models
{
    public class Order_Products
    {
        [ForeignKey("Order")]
        public int OrderId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public int quantity { get; set; }

        public float totalprice { get; set; }


       // public virtual Order? Order { get; set; }

        public virtual Product? Product { get; set; }
    }

}
