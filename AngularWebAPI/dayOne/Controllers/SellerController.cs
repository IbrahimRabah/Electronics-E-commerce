using dayOne.DTO;
using dayOne.Models;
using dayOne.Repositries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dayOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        ISellerRepository sellerRepository;
        private string Mes = "";
        public SellerController(ISellerRepository _sellerRepository)
        {
            sellerRepository= _sellerRepository;
        }
        [HttpGet("GetAllsellerwithStatusWiting")]
        public IActionResult GetAllsellerwithStatusWiting()
        {
            List<Seller> Sellers = (List<Seller>)sellerRepository.GetAll(S => S.Status == status.waiting);
            return Ok(Sellers);
        }

        [HttpGet("GetSingleSeller/{id}")]
        public IActionResult GetSingleSeller(string id)
        {

            SellerDto sellerDto = new SellerDto();
            Seller seller = sellerRepository.GetById(id);
            sellerDto.ApplicationUserId = seller.ApplicationUserId;
            sellerDto.FirstName = seller.ApplicationUser.FirstName;
            sellerDto.LastName = seller.ApplicationUser.LastName;
            sellerDto.Address = seller.ApplicationUser.Address;
            sellerDto.NationalIdImage = seller.NationalIdImage;

            return Ok(sellerDto);
        }

        [HttpGet("AllCustomer")]
        public IActionResult AllCustomer()
        {
            List<Customer> customers = sellerRepository.GetCustomers().ToList();
            return Ok(customers);
        }

        [HttpPut("Confirm/{id}")]
        public IActionResult Confirm(string id)
        {
            Mes = sellerRepository.confirm(id);
            return Ok(Mes);
        }


        [HttpPut("regict/{id}")]
        public IActionResult regict(string id)
        {
            Mes = sellerRepository.reject(id);
            return Ok(Mes);
        }


    }
}
