using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceNetCore.Models
{
    public class ShippingAddress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string country { get; set; }
        public string postal { get; set; }
        public string phone { get; set; }
        public string defaultaddress { get; set; }
        //-----------------------------
        //Relationships
        [ForeignKey("User")]
        public int userID { get; set; }
        public User User { get; set; }
    }
}
