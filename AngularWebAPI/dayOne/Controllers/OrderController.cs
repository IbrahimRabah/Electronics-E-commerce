using dayOne.DTO;
using dayOne.Models;
using dayOne.Repositries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dayOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderRepository OrderRepository;
        private IProductOrderRepository ProductOrderRepository;
        private IProductRepository ProductRepository;
        private ISellerRepository SellerRepository;
        private ICartProductRepository cartProductRepository;
        private ICartRepository cartRepository;
        private IShipperRepository shipperRepository;

        public OrderController(IOrderRepository orderRepository, ICartProductRepository cartProductRepository,
            IShipperRepository shipperRepository, IProductOrderRepository productOrderRepository,IProductRepository productRepository,ISellerRepository sellerRepository)
        {
            OrderRepository = orderRepository;
            this.shipperRepository = shipperRepository;
            ProductOrderRepository = productOrderRepository;
            ProductRepository = productRepository;
            SellerRepository = sellerRepository;
            this.cartProductRepository= cartProductRepository;
          this.shipperRepository= shipperRepository;
        }


        [HttpPost]
        public IActionResult AddOrder(OrderPostDto OrderPostDto)
        {
            LoginDto loginDto = new LoginDto();
            loginDto.Message = string.Empty;
        
            List<ProductCart> productCarts = cartProductRepository.GetAll(p => p.CartId == OrderPostDto.id).ToList();
           
            Product productReal = new Product();   
            foreach (var Product in productCarts)
            {
                productReal = ProductRepository.GetById(Product.ProductId);
                if(productReal.Quantity< Product.Quantity)
                {
                    loginDto.Message+=$"max quantinty of product{productReal.Name} is {productReal.Quantity}";
                }
                
            }
            if (loginDto.Message == string.Empty)
            {
                Order order = new Order();
                order.CustomerId = OrderPostDto.id;

                string[] city = OrderPostDto.address.Split(':');

                List<Shipper> ShipperRegion = shipperRepository.GetAll(s => s.ApplicationUser.Address == city[0]).ToList();

                var ShipperOrderdList= ShipperRegion.OrderBy(s => s.orders.Count());
              

                order.ShipperId = ShipperOrderdList.FirstOrDefault().ApplicationUserId;
                order.Address = OrderPostDto.address;
                order.Phone = OrderPostDto.phone;
                order.Date= DateTime.Now;
                order.OrderProducts = null;
                OrderRepository.Add(order); 
                ShipperOrderdList.FirstOrDefault().orders.ToList().Add(order);
                OrderRepository.SaveChanges();

                foreach (var orderProduct in productCarts)
                {
                    ProductOrderRepository.Add(new OrderProducts { OrderId = order.Id, ProductId = orderProduct.ProductId, Quantity = orderProduct.Quantity });
                    Product product = ProductRepository.GetById(orderProduct.ProductId);
                    product.Quantity -= orderProduct.Quantity;
                    Seller seller = SellerRepository.GetById(product.SellerId);
                    double operation = (product.Price - (product.Price) / 10) * orderProduct.Quantity;
                    seller.Balance += operation;
                    order.TotalPrice += (orderProduct.Quantity * product.Price);
                    SellerRepository.Update(seller);
                    ProductRepository.Update(product);
                    ProductRepository.SaveChanges();

                }
                loginDto.Message = "success";
                return Ok( loginDto);
                
            }
            else
            {
                return Ok(loginDto);
            }
        }

        [HttpGet("NumbersOfOreder")]
        public IActionResult NumbersOfOreder()
        {
            int numberofOreders = 0;
            numberofOreders = OrderRepository.GetAllWithoutFunc().Count();
            return Ok(numberofOreders);
        }
        [HttpGet("LastOrder")]
        public IActionResult LastOrder()
        {
            DateTime DateOfLastOrder;
            Order lastorder = OrderRepository.GetAllWithoutFunc().Last();
            DateOfLastOrder = lastorder.Date;
            return Ok(DateOfLastOrder);
        }
        [HttpGet("Totalprice")]
        public IActionResult Totalprice()
        {
            double totalprice = 0;
            totalprice = OrderRepository.GetTotalprice();
            return Ok(totalprice);
        }


        [HttpGet("Getprofit")]
        public IActionResult Getprofit()
        {
            double profit = 0;
            profit = OrderRepository.Getprofit();
            return Ok(profit);
        }

    }
}
