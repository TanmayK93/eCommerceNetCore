using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceNetCore.Models
{
    public class Cart
    {

        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        //-----------------------------
        //Relationships

        public Product Product { get; set; }
        public User User { get; set; }
    
    }
}
