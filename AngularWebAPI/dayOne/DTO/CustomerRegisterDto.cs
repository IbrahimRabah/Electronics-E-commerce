using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace dayOne.DTO
{
	public class CustomerRegisterDto
    {


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }

       





    }
}
