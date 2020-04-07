using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceNetCore.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public decimal price { get; set; }
        public int rating { get; set; }
        public string sale { get; set; }
        public int discount { get; set; }
        public decimal shippingCost { get; set; }
    }
}
