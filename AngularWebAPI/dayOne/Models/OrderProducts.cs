using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dayOne.Models
{
    public class OrderProducts
    {
        public int Id { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order? Order { get; set; }


        [RegularExpression("[0-9]+", ErrorMessage = "quantity must be greeter than 1")]
        public int Quantity { get; set; }

        [DefaultValue("false")]
        public bool isDeleted { get; set; }


    }
}
