using dayOne.DTO;
using dayOne.Models;
using dayOne.Repositries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dayOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository productRepository;
        private ICategoryRepository categoryRepository;
        private IImageRepository imageRepository;
        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository, IImageRepository imageRepository)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
            this.imageRepository = imageRepository;
        }

        [HttpGet("sellerId/{sellerId}")]
        public IEnumerable<ProductDto> GetAllProductsBysellerId(string sellerId)
        {


            List<ProductDto> productDtos = new List<ProductDto>();
            List<Product> Products = (List<Product>)productRepository.GetAll(c => c.SellerId == sellerId && c.isDeleted == false);
            foreach (Product product in Products)
            {
                List<ProductImageDto> imgs = new List<ProductImageDto>();
                ProductDto productDto = new ProductDto();

                productDto.Id = product.Id;
                productDto.Name = product.Name;
                productDto.Description = product.Description;
                productDto.Price = product.Price;
                productDto.Quantity = product.Quantity;
                productDto.CategoryId = product.CategoryId;
                productDto.SellerId = product.SellerId;
                productDto.AdditionalFeature = product.AdditionalFeature;
                productDto.MainImage = product.MainImage;

                productDto.ProductImages = imgs;
                productDtos.Add(productDto);
            }
            return productDtos;

        }

        [HttpGet]
        public IEnumerable<ProductDto> GetAllProducts()
        {
            List<ProductDto> productDtos = new List<ProductDto>();
            List<Product> Products = (List<Product>)productRepository.GetAll(c => c.isDeleted == false);
            foreach (Product product in Products)
            {
                List<ProductImageDto> imgs = new List<ProductImageDto>();
                ProductDto productDto = new ProductDto();

                productDto.Id = product.Id;
                productDto.Name = product.Name;
                productDto.Description = product.Description;
                productDto.Price = product.Price;
                productDto.Quantity = product.Quantity;
                productDto.CategoryId = product.CategoryId;
                productDto.SellerId = product.SellerId;
                productDto.MainImage = product.MainImage;
                productDto.AdditionalFeature = product.AdditionalFeature;

                productDtos.Add(productDto);
            }
            return productDtos;
        }
        [HttpGet("{CategoryName}")]
        public IEnumerable<ProductDto> GetAllProductsByCategoryName(string CategoryName)
        {
            int CategoryId = categoryRepository.GetIdOfCategryByName(CategoryName);

            List<ProductDto> productDtos = new List<ProductDto>();
            List<Product> Products = (List<Product>)productRepository.GetAll(c => c.CategoryId == CategoryId && c.isDeleted == false);
            foreach (Product product in Products)
            {
                List<ProductImageDto> imgs = new List<ProductImageDto>();
                ProductDto productDto = new ProductDto();

                productDto.Id = product.Id;
                productDto.Name = product.Name;
                productDto.Description = product.Description;
                productDto.Price = product.Price;
                productDto.Quantity = product.Quantity;
                productDto.CategoryId = product.CategoryId;
                productDto.SellerId = product.SellerId;
                productDto.AdditionalFeature = product.AdditionalFeature;
                productDto.MainImage = product.MainImage;

                productDto.ProductImages = imgs;
                productDtos.Add(productDto);
            }
            return productDtos;

        }
        [HttpGet("{id:int}")]
        public ProductDto GetSingleProduct(int id)
        {
            List<ProductImageDto> imgs = new List<ProductImageDto>();
            ProductDto productDto = new ProductDto();
            Product product = productRepository.GetById(id);
            productDto.Id = product.Id;
            productDto.Name = product.Name;
            productDto.Description = product.Description;
            productDto.Price = product.Price;
            productDto.Quantity = product.Quantity;
            productDto.CategoryId = product.CategoryId;
            productDto.SellerId = product.SellerId;
            productDto.AdditionalFeature = product.AdditionalFeature;
            productDto.MainImage = product.MainImage;

            foreach (var img in product.ProductImages)
            {
                imgs.Add(new ProductImageDto() { Id = img.Id, ProductId = img.ProductId, Image = img.Image });

            }

            productDto.ProductImages = imgs;
            return productDto;
        }
        [HttpDelete("{id:int}")]
        public void DeleteProduct(int id)
        {
            productRepository.SoftDelete(id);
            productRepository.SaveChanges();
        }
        [HttpPost]
        public void AddProduct([FromForm] PostProductDto postProductDto)
        {
            List<AdditionalFeature> AdditionalFeature = new List<AdditionalFeature>();
            string img = "";
            Product product = new Product();
            product.Name = postProductDto.Name;
            product.Price = postProductDto.Price;
            product.Quantity = postProductDto.Quantity;
            product.Description = postProductDto.Description;
            product.CategoryId = postProductDto.CategoryId;
            product.SellerId = postProductDto.SellerId;
            product.Rate = 0;

          
            AdditionalFeature.Add(new AdditionalFeature() { key = postProductDto.FeaturKeys1, value = postProductDto.FeaturValues1});
            AdditionalFeature.Add(new AdditionalFeature() { key = postProductDto.FeaturKeys2, value = postProductDto.FeaturValues2 });

            product.AdditionalFeature = AdditionalFeature;
            product.ProductImages = null;

            product.MainImage = ImgHelper.UploadImg(postProductDto.MainImage, "images");
            productRepository.Add(product);
            productRepository.SaveChanges();

           

        }
        [HttpPut("{id}:int")]
        public void UpdateProduct(ProductDto productDto, int id)
        {

            Product product = productRepository.GetById(id);
            product.Name = productDto.Name;
            product.Price = productDto.Price;
            product.Quantity = productDto.Quantity;
            product.Description = productDto.Description;
            product.CategoryId = productDto.CategoryId;
            product.SellerId = productDto.SellerId;
            product.AdditionalFeature = productDto.AdditionalFeature;
            product.MainImage = productDto.MainImage;
            productRepository.Update(product);

            productRepository.SaveChanges();


        }

    }
}
