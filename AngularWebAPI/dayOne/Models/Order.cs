using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace dayOne.Models
{
    public enum orderStutes
    {
        onStock,
        onWay,
        delivered
    }
    public class Order
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public string Address { get; set; }
        [RegularExpression("[0-9]{11}", ErrorMessage = "Must be numbers only  and 11 number  Ex:01234567891")]
        public string Phone { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
     
        [DefaultValue("false")]
        public bool isDeleted { get; set; }

        [ForeignKey("Shipper")]
        public string? ShipperId { get; set; }
        public Shipper? Shipper { get; set; }

        public orderStutes stutes{ get; set; }

        [ForeignKey("Customer")]
        public string CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public IEnumerable<OrderProducts>? OrderProducts; 

    }
}
