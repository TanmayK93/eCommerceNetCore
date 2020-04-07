using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceNetCore.Models
{
    public class CommentList
    {
        public string productName { get; set; }
        public string description { get; set; }
        public int rating { get; set; }
        public string username { get; set; }
    }
}
