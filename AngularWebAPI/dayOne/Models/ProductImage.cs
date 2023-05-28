using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace dayOne.Models
{
    public class ProductImage
    {
       public int Id { get; set; }
        public string Image { get; set; }
        [DefaultValue("false")]
        public bool isDeleted { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
