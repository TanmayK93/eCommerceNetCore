using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eCommerceNetCore.Models;

namespace eCommerceNetCore.Models
{
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int OrderDetailId { get; set; }

        public int OrderId { get; set; }

        //Products
        public int productId { get; set; }
        //public string name { get; set; }
        //public string image { get; set; }
        public int quantity { get; set; }
        //public decimal price { get; set; }

        //User
        public int userid { get; set; }

        public Product Product { get; set; }
        public User User { get; set; }
    }
}