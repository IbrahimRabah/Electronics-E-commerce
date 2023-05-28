using dayOne.DTO;
using dayOne.Models;
using dayOne.Repositries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.X86;

namespace dayOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private string Mes = "";
        private IOrderRepository _OrderRepository;
        private IShipperRepository _shipperRepository;
        public ShipperController(IShipperRepository shipperRepository, 
            IOrderRepository orderRepository)
        {
            this._OrderRepository = orderRepository;
          this._shipperRepository = shipperRepository;
        }
        [HttpGet("GetAllShiperwithStatusWiting")]
        public IActionResult GetAllShiperwithStatusWiting()
        {
            List<Shipper> shippers = (List<Shipper>)_shipperRepository.GetAll(S => S.Status == status.waiting);
            List<ShipperDto> WaitingShippers = new List<ShipperDto>();
            foreach (Shipper shipper in shippers)
            {
                WaitingShippers.Add(new ShipperDto { FirstName = shipper.ApplicationUser.FirstName,
                LastName= shipper.ApplicationUser.LastName,
                Address = shipper.ApplicationUser.Address,
                Email = shipper.ApplicationUser.Email,
                Status= shipper.Status,
                LicenseImage= shipper.LicenseImage,
                Ssd = shipper.Ssd,
                ApplicationUserId= shipper.ApplicationUserId,
                });
            }
            return Ok(WaitingShippers);

        }

        [HttpGet]
        public IActionResult  GetAllShippers()
        {
            List<ShipperDataDto> shipperDataDtos = new List<ShipperDataDto>();
            List<Shipper> shippers = _shipperRepository.GetAll(s => s.ApplicationUser.isDeleted==false).ToList();
            foreach (Shipper shipper in shippers)
            {
                shipperDataDtos.Add(

                    new ShipperDataDto
                    {

                        Id = shipper.ApplicationUserId,

                        Name = shipper.ApplicationUser.FirstName +" "+ shipper.ApplicationUser.LastName,

                        Address= shipper.ApplicationUser.Address,
                        stutes= (orderStutes)shipper.Status


                    });

            }
            return Ok(shipperDataDtos) ;
        }

        [HttpGet("GetSingleShipper/{id}")]
        public IActionResult GetSingleShipper(string id)
        {

            ShipperDto ShipperDto = new ShipperDto();
            Shipper shipper = _shipperRepository.GetById(id);
            ShipperDto.ApplicationUserId=shipper.ApplicationUserId;
            ShipperDto.FirstName= shipper.ApplicationUser.FirstName;
            ShipperDto.LastName = shipper.ApplicationUser.LastName;
            ShipperDto.Address = shipper.ApplicationUser.Address;
            ShipperDto.Status = shipper.Status;
            ShipperDto.LicenseImage= shipper.LicenseImage;
            ShipperDto.Ssd = shipper.Ssd;

            return  Ok(ShipperDto);
        }


        [HttpPut]
        [Route("{id:alpha}")]//api/Department/1 Put
        public IActionResult Edit(string id, Shipper newShipper)
        {
            if (ModelState.IsValid)
            {
                 _shipperRepository.Edit(id,newShipper);


                return Ok("Updated");
            }
            return BadRequest(ModelState);

        }



        [HttpDelete("{id:alpha}")]//api/Department/1 Delete
        public IActionResult Delete(string id)
        {
            try
            {
                _shipperRepository.SoftDelete(id);
               
                return new StatusCodeResult(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Confirm/{id}")]       
        public IActionResult Confirm(string id)
        {
            Mes = _shipperRepository.confirm(id);
            return Ok(Mes);
        }


        [HttpPut("regict/{id}")]
        public IActionResult regict(string id)
        {
            Mes = _shipperRepository.reject(id);
            return Ok(Mes);
        }

        [HttpGet("Allorder/{shid}")]
        public IActionResult GetOrders(string shid)
        {
            IEnumerable<orderPure> order =_shipperRepository.GetOrders(shid);
            return Ok(order);

        }
        [HttpPut("OrderDone/{OrderId}/{shid}")]
        public IActionResult OrderDone(int OrderId, string shid)
        {
            _shipperRepository.OrderDone(OrderId, shid);
            return Ok();

        }
    }
}
