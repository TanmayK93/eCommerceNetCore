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
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingAddressesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ShippingAddressesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ShippingAddresses
        [HttpGet]
        public IEnumerable<ShippingAddress> GetShippingAddress()
        {
            return _context.ShippingAddress;
        }

        // GET: api/ShippingAddresses/5
        [HttpGet("{id}")]
        public IEnumerable<ShippingAddress> GetShippingAddress([FromRoute] int id)
        {
            var results = from items in _context.ShippingAddress
                          where items.userID == id
                          select items;
            
            return results;
        }

        // PUT: api/ShippingAddresses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShippingAddress([FromRoute] int id, [FromBody] ShippingAddress shippingAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shippingAddress.id)
            {
                return BadRequest();
            }

            _context.Entry(shippingAddress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShippingAddressExists(id))
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

        // POST: api/ShippingAddresses
        [HttpPost]
        public async Task<IActionResult> PostShippingAddress([FromBody] ShippingAddress shippingAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ShippingAddress.Add(shippingAddress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShippingAddress", new { id = shippingAddress.id }, shippingAddress);
        }

        // DELETE: api/ShippingAddresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShippingAddress([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shippingAddress = await _context.ShippingAddress.FindAsync(id);
            if (shippingAddress == null)
            {
                return NotFound();
            }

            _context.ShippingAddress.Remove(shippingAddress);
            await _context.SaveChangesAsync();

            return Ok(shippingAddress);
        }

        private bool ShippingAddressExists(int id)
        {
            return _context.ShippingAddress.Any(e => e.id == id);
        }
    }
}