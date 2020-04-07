using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceNetCore.Models
{
    public class Comments
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int rating { get; set; }
        public string text { get; set; }
        //-----------------------------
        //Relationships
        public Product Product { get; set; }
        public User User { get; set; }
    }
}
