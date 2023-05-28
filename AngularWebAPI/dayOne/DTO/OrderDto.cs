using dayOne.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace dayOne.DTO
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int TotalPrice { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
       
        public string? ShipperId { get; set; }
        
        public string? CustomerId { get; set; }
       
        public List<OrderProductDto> OrderProductsDto { get; set; }
    }
}
