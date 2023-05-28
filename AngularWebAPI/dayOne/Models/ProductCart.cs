using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace dayOne.Models
{
    public class ProductCart
    {
        public int Id { get; set; }
        [DefaultValue(1)]
        public int Quantity { get; set; } = 1;
     
        [ForeignKey("Cart")]
        public string CartId { get; set; }
        public Cart Cart { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public  Product Product{ get; set; }

        [DefaultValue("false")]
        public bool isDeleted { get; set; }


    }
}
