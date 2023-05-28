using dayOne.DTO;
using dayOne.Models;
using dayOne.Repositries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dayOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCartController : ControllerBase
    {

        ICartProductRepository cartProductRepository;
        public ProductCartController(ICartProductRepository cartProductRepository)
        {
           
            this.cartProductRepository = cartProductRepository;

        }
       


        [HttpPost("AddCartProduct")]
        public IActionResult AddCart(rproductCartDto rproductCartDto)
        {

            cartProductRepository.Add(new ProductCart()
            {
                CartId = rproductCartDto.CartId,
                //Quantity= rproductCartDto.Quantity,
                ProductId= rproductCartDto.ProductId,


            }) ;

            cartProductRepository.SaveChanges();
            LoginDto loginDto = new LoginDto();
            loginDto.Message = "success";
            return Ok(loginDto);

        }




        [HttpPut("{id:int}")]
        public void UpdateSingleCartByCustomerID(int id, ProductCartDto newProductcartDto)
        {
          
           ProductCart oldProductCart= cartProductRepository.GetById(id);
            oldProductCart.Quantity= newProductcartDto.Quantity;
            cartProductRepository.Update(oldProductCart);
            cartProductRepository.SaveChanges();


        }




        [HttpGet ("GetAllProdectCart/{customerId}")]
        /*[HttpGet("{customerId:alpha}")]*/
        public IActionResult GetAllProdectCart(string customerId)
        {
            List<ProductCartDto> ProductCart = cartProductRepository.GetAllProductCarts(customerId).ToList();
            return Ok(ProductCart);
        }


        [HttpDelete("{id:int}")]
        public IActionResult DeleteProductCart(int id)
        {
            cartProductRepository.HardDelete(id);
            cartProductRepository.SaveChanges();
            /* string Mes = cartProductRepository.DeleteItem(id);*/
            LoginDto loginDto= new LoginDto();
            loginDto.Message = "Deleted";
            return Ok(loginDto);
        }
        [HttpPut("IncreamentByOne/{id:int}")]
        public IActionResult IncreamentByOne(int id)
        {
            string Mes = cartProductRepository.IncreamentByOne(id);
            LoginDto loginDto = new LoginDto();
            loginDto.Message = "Increased";
            return Ok(loginDto);
        }
        [HttpPut("DecreamentByOne/{id:int}")]
        public IActionResult DecreamentByOne(int id)
        {
            string Mes = cartProductRepository.DecreamentByOne(id);
            LoginDto loginDto = new LoginDto();
            loginDto.Message = "Decreased";
            return Ok(loginDto);
        }



        //[HttpDelete("DeleteCartProduct {id:int}")]


        //public void DeleteProductCart(int id)
        //{


        //    cartProductRepository.HardDelete(id);
        //    cartProductRepository.SaveChanges();    


        //}


    }
}
