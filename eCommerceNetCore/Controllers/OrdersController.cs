using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eCommerceNetCore.Models;

namespace eCommerceNetCore.Controllers
{
    public class OrdDetails
    {
        public int userid { get; set; }
        public decimal total { get; set; }

    }
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;

            if (context.Orders.Count() == 0)
            {
                var orderJohn = new Order
                {
                    OrderId = 1238988,
                    date = "April,1 2019",
                    Total = 10.20M
                };

                var orderDetailJohn = new OrderDetail
                {
                    OrderId = 1238988,
                    productId = 1,
                    userid = 3,
                    quantity = 50,
                };

                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Orders ON");
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Orders OFF");

                    context.Orders.Add(orderJohn);
                    context.OrderDetails.Add(orderDetailJohn);
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Orders ON");
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Orders OFF");

                }
                finally
                {
                    context.Database.CloseConnection();
                }

            }
        }

        // GET: api/Orders
        [HttpGet]
        public IEnumerable<Order> GetOrders()
        {
            return _context.Orders;
        }

        // GET: api/Orders/5
        [HttpGet("{userid}")]
        public IEnumerable<OrderList> GetOrder([FromRoute] int userid)
        {
            var results = (from ord in _context.Orders
                           join ordDtl in _context.OrderDetails on ord.OrderId equals ordDtl.OrderId
                           where ordDtl.userid == userid
                           select new OrderList
                           {
                               id = ordDtl.productId,
                               orderId = ordDtl.OrderId,
                               name = ordDtl.Product.name,
                               image = ordDtl.Product.image,
                               quantity = ordDtl.quantity,
                               price = ordDtl.Product.price,
                               date = ord.date,
                               total = ord.Total,
                               username = ordDtl.User.username
                           }).ToList();
            return results;
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder([FromRoute] int id, [FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<IActionResult> PostOrder([FromBody] OrdDetails orderdetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shoppingCart = _context.Cart.Where(c => c.UserId == orderdetail.userid);

            Random generator = new Random();
            String r = generator.Next(0, 9999999).ToString("D6");
            int orderno = Int32.Parse(r);
            string date = DateTime.Now.ToString("D");

            var orders = new Order
            {
                OrderId = orderno,
                date = date,
                Total = orderdetail.total
            };

            _context.Database.OpenConnection();
            try
            {
                _context.Orders.Add(orders);
                _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Orders ON");
                await _context.SaveChangesAsync();
                _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Orders OFF");

                foreach (Cart item in shoppingCart)
                {
                    var orderDetailJohn = new OrderDetail
                    {
                        OrderId = orderno,
                        productId = item.ProductId,
                        userid = item.UserId,
                        quantity = item.Quantity,
                    };

                    _context.OrderDetails.Add(orderDetailJohn);
                }

                _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Orders ON");
                await _context.SaveChangesAsync();
                _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Orders OFF");


            }
            finally
            {
                _context.Database.CloseConnection();
            }

            _context.Cart.Remove(_context.Cart.First(t => t.UserId == orderdetail.userid));
            await _context.SaveChangesAsync();



            //  _context.Cart.Remove(_context.Cart.Find(orderdetail.userid));


            return Ok();
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return Ok(order);
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}