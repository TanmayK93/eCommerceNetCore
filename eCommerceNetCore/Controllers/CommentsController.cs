using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eCommerceNetCore.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CommentsController(AppDbContext context)
        {
            _context = context;
            if (context.Comment.Count() == 0)
            {
                context.Comment.Add(new eCommerceNetCore.Models.Comments
                {
                    UserId = 3,
                    ProductId = 2,
                    rating = 4,
                    text = "It works Awesome"
                });
                context.SaveChanges();
            }
        }

        // GET: api/Comments
        [HttpGet]
        public IEnumerable<Comments> GetComment()
        {
            return _context.Comment;
        }

        // GET: api/Comments/5
        [HttpGet("{id}")]
        public IEnumerable<CommentList> GetComment([FromRoute] int id)
        {

            var results = (from items in _context.Comment
                           where items.ProductId == id
                           select new CommentList
                           {
                               username = items.User.username,
                               productName = items.Product.name,
                               description = items.text,
                               rating = items.rating
                           }).ToList();

            return results;
        }

        // PUT: api/Comments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComments([FromRoute] int id, [FromBody] Comments comments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comments.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(comments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentsExists(id))
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

        // POST: api/Comments
        [HttpPost]
        public async Task<IActionResult> PostComments([FromBody] Comments comments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Comment.Add(comments);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CommentsExists(comments.ProductId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetComments", new { id = comments.ProductId }, comments);
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComments([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comments = await _context.Comment.FindAsync(id);
            if (comments == null)
            {
                return NotFound();
            }

            _context.Comment.Remove(comments);
            await _context.SaveChangesAsync();

            return Ok(comments);
        }

        private bool CommentsExists(int id)
        {
            return _context.Comment.Any(e => e.ProductId == id);
        }
    }
}