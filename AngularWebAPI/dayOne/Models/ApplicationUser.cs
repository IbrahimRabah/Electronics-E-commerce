using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

namespace dayOne.Models
{
	public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        [DefaultValue("false")]
        public bool isDeleted { get; set; }



    }
}
