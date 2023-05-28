using dayOne.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace dayOne.DTO
{
    public class ShipperDto
    {
        public string ApplicationUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public status Status { get; set; }
        public string LicenseImage { get; set; }
        public string Ssd { get; set; }
    }
}
