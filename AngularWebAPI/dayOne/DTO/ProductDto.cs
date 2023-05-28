using dayOne.Models;

namespace dayOne.DTO
{
    public class ProductDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MainImage { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public string? SellerId { get; set; }
        public int Rate { set; get; }
        public List<ProductImageDto>? ProductImages { get; set; }
        public IEnumerable<AdditionalFeature>? AdditionalFeature { get; set; }
    }
}
