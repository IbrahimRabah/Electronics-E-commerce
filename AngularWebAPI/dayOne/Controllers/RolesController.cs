using dayOne.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace dayOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        
        private readonly RoleManager<IdentityRole> roleManager;
        public RolesController(RoleManager<IdentityRole> _roleManager) 
        {
           roleManager= _roleManager;
        }
        [HttpPost]
        public async  Task<IActionResult> Addrole(string role)
        {
            IdentityRole roleModel = new IdentityRole();
            roleModel.Name =role;
            IdentityResult result = await roleManager.CreateAsync(roleModel);
            if(result.Succeeded)
            {
                return Ok("Added");
            }
            else
            {
                return BadRequest(result.Errors.FirstOrDefault().Description);
            }
             
        }
    }
}
