using dayOne.DTO;
using dayOne.Models;
using dayOne.Repositries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dayOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
       private ICartRepository CartRepository;

        private ICartProductRepository CardProductRepository;

        public CartController(ICartRepository cartRepository, ICartProductRepository cardProductRepository)
        {
            CartRepository = cartRepository;
            CardProductRepository= cardProductRepository;
        }

   
        [HttpGet("{id}")]
        public CartDto GetSingleCartByCustomerID(string id)
        {
            CartDto cartDto = new CartDto();
            List<ProductCartDto> producrCartDtos = new List<ProductCartDto>();
            Cart cart = CartRepository.GetById(id);
            cartDto.CustomerCartId = cart.CustomerCartId;
            foreach (var cartProducts in cart.CartProducts)
            {
                producrCartDtos.Add((ProductCartDto)(IEnumerable<ProductCartDto>)cartProducts);
            }

            cartDto.CartProductsDto = producrCartDtos;
            return cartDto;
        }

        [HttpPut("{id}")]
        public IActionResult DeleteCartProdectByCustomerID(string id)
        {
            
            Cart oldcart = CartRepository.GetById(id);

            oldcart.CartProducts = null;
            CartRepository.SaveChanges();
            LoginDto loginDto = new LoginDto();
            loginDto.Message = "Success";
            return Ok(loginDto);

        }
        /*

                [HttpPost("AddCart")]
                public void AddCart(CartDto cartDto)
                {

                    Cart cart = new Cart();
                    cart.CustomerCartId = cartDto.CustomerCartId;

                    cart.CartProducts = null;
                    CartRepository.Add(cart);
                    CartRepository.SaveChanges();

                    foreach (var cartProduct in cartDto.CartProductsDto)
                    {
                        CardProductRepository.Add( new ProductCart { ProductId =cartProduct.ProductId , CartId =cart.CustomerCartId });
                        CardProductRepository.SaveChanges();
                    }

                }*/
    }
}
