using dayOne.Models;

namespace dayOne.DTO
{
    public class ShipperSingleData
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public orderStutes Stutes { get; set; }
        public string City { get; set; }
        public double TotalPrice { get; set; }
        public string Phone { get; set; }
        public DateTime Date { get; set; }
        public orderStutes Status { get; internal set; }
    }
}
