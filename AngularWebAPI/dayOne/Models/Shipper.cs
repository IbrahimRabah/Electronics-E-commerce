using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dayOne.Models
{
    public class Shipper
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        [DefaultValue("waiting")]
        public status Status { get; set; }
        public string LicenseImage { get; set; }
        public string Ssd { get; set; }

        public IEnumerable<Order>? orders { get; set; }


    }
}
