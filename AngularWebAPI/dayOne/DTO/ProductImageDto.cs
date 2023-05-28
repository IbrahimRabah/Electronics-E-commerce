using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace dayOne.DTO
{
    public class ProductImageDto
    {
        public int? Id { get; set; }
        public string Image { get; set; }
        public int? ProductId { get; set; }
    }
}
