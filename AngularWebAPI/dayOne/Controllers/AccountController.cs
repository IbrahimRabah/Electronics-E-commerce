using dayOne.DTO;
using dayOne.Models;
using dayOne.Repositries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace dayOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configuration;
        private ICartRepository cartRepository;
        private IAccountRepository accountRepository;
        public AccountController(UserManager<ApplicationUser> userManager, IConfiguration configuration
            , IAccountRepository accountRepository,ICartRepository cartRepository)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.cartRepository= cartRepository;
            this.accountRepository = accountRepository;
        }


        [HttpPost("ShipperRegister")]
        public async Task<IActionResult> ShipperRegister([FromForm] RegisterUserDto registerUserDto)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = new ApplicationUser();
                applicationUser.FirstName = registerUserDto.FirstName;
                applicationUser.LastName = registerUserDto.LastName;
                applicationUser.Email = registerUserDto.Email;
                applicationUser.Address = registerUserDto.Address;
                applicationUser.UserName = registerUserDto.UserName;
                applicationUser.Email = registerUserDto.Email;
               
              
                IdentityResult result = await userManager.CreateAsync(applicationUser, registerUserDto.Password);
                RegisterDto registerDto = new RegisterDto();

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(applicationUser, "Shipper");
                    Shipper shipper = new Shipper();
                    shipper.ApplicationUserId = applicationUser.Id;
                    shipper.LicenseImage = ImgHelper.UploadImg(registerUserDto.LicenseImage, "images");
                    shipper.Ssd = registerUserDto.Ssd;
                  //  shipper.Status = status.waiting;

                    accountRepository.AddShipper(shipper);

                    registerDto.Message = "success";
                    return Ok(registerDto);
                }
                else
                    registerDto.Message = "Failed";
                    return BadRequest(registerDto);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }





        [HttpPost("CustomerRegister")]
        public async Task<IActionResult> CustomerRegister(CustomerRegisterDto registerUserDto)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = new ApplicationUser();
                applicationUser.FirstName = registerUserDto.FirstName;
                applicationUser.LastName = registerUserDto.LastName;
                applicationUser.Email = registerUserDto.Email;
                applicationUser.Address = registerUserDto.Address;
                applicationUser.UserName = registerUserDto.UserName;
                applicationUser.Email = registerUserDto.Email;
                applicationUser.isDeleted = false;
                IdentityResult result = await userManager.CreateAsync(applicationUser, registerUserDto.Password);
                RegisterDto registerDto =new RegisterDto();

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(applicationUser, "Customer");
                    Customer customer = new Customer();
                    customer.ApplicationUserId = applicationUser.Id;
                    /*        customer.Cart = new Cart();*/

                    customer.Orders = null;

                    accountRepository.AddCustomer(customer);

                    cartRepository.Add(new Cart() { CustomerCartId = applicationUser.Id });
                    cartRepository.SaveChanges();
                    registerDto.Message = "success";
                    return Ok(registerDto);
                }
                else
                    registerDto.Message = "Failed";
                    return BadRequest(registerDto);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost("AdminRegister")]
        public async Task<IActionResult> AdminRegister(CustomerRegisterDto registerUserDto)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = new ApplicationUser();
                applicationUser.FirstName = registerUserDto.FirstName;
                applicationUser.LastName = registerUserDto.LastName;
                applicationUser.Email = registerUserDto.Email;
                applicationUser.Address = registerUserDto.Address;
                applicationUser.UserName = registerUserDto.UserName;
                applicationUser.Email = registerUserDto.Email;
                applicationUser.isDeleted = false;
                IdentityResult result = await userManager.CreateAsync(applicationUser, registerUserDto.Password);
                RegisterDto registerDto = new RegisterDto();

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(applicationUser, "Admin");
                   
                    registerDto.Message = "success";
                    return Ok(registerDto);
                }
                else
                    registerDto.Message = "Failed";
                return BadRequest(registerDto);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        //seller Register
        [HttpPost("Sellerregister")]
        public async Task<IActionResult> SellerRegister([FromForm] sellerregister registerUserDto)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = new ApplicationUser();
                applicationUser.FirstName = registerUserDto.FirstName;
                applicationUser.LastName = registerUserDto.LastName;
                applicationUser.Email = registerUserDto.Email;
                applicationUser.Address = registerUserDto.Address;
                applicationUser.UserName = registerUserDto.UserName;
                applicationUser.Email = registerUserDto.Email;
                applicationUser.isDeleted = false;
                IdentityResult result = await userManager.CreateAsync(applicationUser, registerUserDto.Password);
                RegisterDto registerDto = new RegisterDto();

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(applicationUser, "seller");
                    Seller seller = new Seller();
                    seller.ApplicationUserId = applicationUser.Id;
                    seller.Age = registerUserDto.Age;
                    seller.NationalIdImage =  ImgHelper.UploadImg(registerUserDto.NationalIdImage, "images");
                    seller.Balance = registerUserDto.Balance;
                    seller.Status = status.waiting;

                    accountRepository.AddSeller(seller);

                    registerDto.Message = "success";
                    return Ok(registerDto);
                }
                else
                    registerDto.Message = "Failed";
                return BadRequest(registerDto);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDto userDto)
        {

            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = await userManager.FindByNameAsync(userDto.userName);//.FindByNameAsync(userDto.UserName);
                LoginDto loginDto = new LoginDto();
                if (applicationUser != null && await userManager.CheckPasswordAsync(applicationUser, userDto.Password))
                {

                    var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecryKey"]));
                    SigningCredentials credentials = new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256);

                    List<Claim> myClaims = new List<Claim>();

                    myClaims.Add(new Claim(ClaimTypes.NameIdentifier, applicationUser.Id));
                    myClaims.Add(new Claim(ClaimTypes.Name, applicationUser.UserName));
                    myClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                    if (await userManager.IsInRoleAsync(applicationUser, "Shipper"))
                    {
                        myClaims.Add(new Claim(ClaimTypes.Role, "Shipper"));
                    }
                    else if (await userManager.IsInRoleAsync(applicationUser, "Seller"))
                    {
                        myClaims.Add(new Claim(ClaimTypes.Role, "Seller"));
                    }
                    else if (await userManager.IsInRoleAsync(applicationUser, "Customer"))
                    {
                        myClaims.Add(new Claim(ClaimTypes.Role, "Customer"));
                    }
                    else if (await userManager.IsInRoleAsync(applicationUser, "Admin"))
                    {
                        myClaims.Add(new Claim(ClaimTypes.Role, "Admin"));
                    }
                    else
                    {
                        myClaims.Add(new Claim(ClaimTypes.Role, "NoRole"));
                    }
                    JwtSecurityToken MyToken = new JwtSecurityToken(
                        issuer: configuration["JWT:ValidIss"],
                        audience: configuration["JWT:ValidAud"],
                        expires: DateTime.Now.AddHours(6),
                        claims: myClaims,


                        signingCredentials: credentials
                        );
                    loginDto.Message = "success";

                    return Ok(
                        new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(MyToken),
                            expiration = MyToken.ValidTo,
                            Messege = "success"

                        });

                }
                else
                {
                    loginDto.Message = "invalid userName";
                    return BadRequest(loginDto);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
