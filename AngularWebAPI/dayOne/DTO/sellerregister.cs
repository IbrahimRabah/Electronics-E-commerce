using System.ComponentModel.DataAnnotations;

namespace dayOne.DTO
{
    public class sellerregister
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
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public int Age { get; set; }
        public double Balance { get; set; }
        public IFormFile NationalIdImage { get; set; }
    }
}
