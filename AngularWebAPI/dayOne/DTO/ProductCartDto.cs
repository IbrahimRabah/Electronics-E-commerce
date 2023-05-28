using dayOne.Models;

namespace dayOne.DTO
{
    public class ProductCartDto
    {
        //public string? CartId { get; set; }
      
        public int Quantity { get; set; }
        public int productcartId { get; set; }
        // public Product Product { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string MainImage { get; set; }
        public double Price { get; set; } 
    }

    
}
