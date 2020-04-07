using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceNetCore.Models
{
    public class OrderList
    {
        public int id { get; set; }
        public int orderId { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        public decimal total { get; set; }
        public string date { get; set; }
        public string username { get; set; }
    }
}
