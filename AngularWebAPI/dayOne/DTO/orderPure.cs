using System.ComponentModel.DataAnnotations;

namespace dayOne.DTO
{
    public class orderPure
    {
        public int Id { get; set; }
        public int TotalPrice { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

   

        public string? ShipperId { get; set; }

        public string? CustomerId { get; set; }
    }
}
