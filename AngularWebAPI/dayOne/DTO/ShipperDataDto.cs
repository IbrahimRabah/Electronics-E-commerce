using dayOne.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace dayOne.DTO
{
    public class ShipperDataDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public orderStutes stutes { get; set; }
        //public string City { get; set; }
        //public double TotalPrice { get; set; }
        //public string Phone { get; set; }
        //public DateTime Date { get; set; }
        //public orderStutes stutes { get; set; }


    }
}
