namespace dayOne.DTO
{
    public class PostProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile MainImage { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public string SellerId { get; set; }
        public string  FeaturKeys1 { get; set; }
        public string FeaturValues1 { get; set; }
        public string FeaturKeys2 { get; set; }
        public string FeaturValues2 { get; set; }

    }
}
