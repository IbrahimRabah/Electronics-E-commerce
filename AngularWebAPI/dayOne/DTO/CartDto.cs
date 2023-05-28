using dayOne.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace dayOne.DTO
{
    public class CartDto
    {

        public string CustomerCartId { get; set; }
         public List<ProductCartDto> CartProductsDto { get; set; }
      
    }
}
