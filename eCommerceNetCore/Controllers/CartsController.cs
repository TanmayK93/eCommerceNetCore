using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerceNetCore.Models;

namespace WebApplication1.Controllers
{
    public class Carts
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string type { get; set; }
    }


    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly AppDbContext _context;

        private string status = "";

        public CartsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Carts
        [HttpGet]
        public IEnumerable<Cart> GetCart()
        {
            return _context.Cart;
        }

        // GET: api/Carts/5
        [HttpGet("{userid}")]
      //  public IEnumerable<ShopList> GetCart([FromRoute] int id)
        public IEnumerable<ShopList> GetCart([FromRoute] int userid)
        {
            var results = (from items in _context.Cart
                           where items.UserId == userid
                           select new ShopList
                           {
                               id = items.Product.id,
                               name = items.Product.name,
                               image = items.Product.image,
                               price = items.Product.price,
                               quantity = items.Quantity
                           }).ToList();
            return results;
        }

        // PUT: api/Carts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCart([FromRoute] int id, [FromBody] Cart cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cart.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(cart).State = EntityState.Modified;

            try
            {
                if (CartExists(cart.ProductId))
                {
                    _context.Cart.Update(cart);
                    await _context.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(id))
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

        // POST: api/Carts
        [HttpPost]
        public async Task<IActionResult> PostCart([FromBody] Carts cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = _context.Cart.FirstOrDefault(item => item.ProductId == cart.ProductId && item.UserId == cart.UserId);

            if (cart.type.Equals("add") && entity == null)
            {
                _context.Cart.Add(new eCommerceNetCore.Models.Cart
                {
                    ProductId = cart.ProductId,
                    UserId = cart.UserId,
                    Quantity = cart.Quantity
                });
            }
            else 
            {
                if(cart.type.Equals("update"))
                {
                    entity.Quantity = cart.Quantity;
                    _context.Cart.Update(entity);
                } else
                {
                    entity.Quantity += cart.Quantity;
                    _context.Cart.Update(entity);
                }
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CartExists(cart.ProductId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            // return CreatedAtAction("GetCart", new { id = cart.UserId }, cart);
            return Ok();
        }

        // DELETE: api/Carts/5
        [HttpDelete("{userid}/{productid}")]
        public async Task<IActionResult> DeleteCart([FromRoute] int userid, [FromRoute] int productid) /// check this
        {

            if (_context.Cart.Where(t => t.UserId == userid).Count() > 0 && CartExists(productid))
            {
                _context.Cart.Remove(_context.Cart.First(t => t.ProductId == productid));
                await _context.SaveChangesAsync();
                status = "Deleted";
            } else
            {
                status = "Failed";
            }

            return Ok(status);
        }

        private bool CartExists(int id)
        {
            return _context.Cart.Any(e => e.ProductId == id);
        }

        private bool CartUserExists(int id)
        {
            return _context.Cart.Any(e => e.UserId == id);
        }
    }
}