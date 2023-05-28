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
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string MainImage { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        [DefaultValue("false")]
        public bool isDeleted { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [ForeignKey("Seller")]
        public string? SellerId { get; set; }
        public Seller? Seller { get; set; }

       public int Rate { set; get; }
        public IEnumerable<ProductCart>? CartProducts { get; set; }
        public IEnumerable<ProductImage>? ProductImages { get; set; }

        public IEnumerable<OrderProducts>? OrderProducts { get; set; }
        public IEnumerable<AdditionalFeature>? AdditionalFeature { get; set; }





    }
}
