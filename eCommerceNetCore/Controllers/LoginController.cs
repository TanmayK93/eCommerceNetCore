using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using eCommerceNetCore.Models;
using eCommerceNetCore.Utils;

namespace WebApplication1.Controllers
{
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class Response
    {
        public bool Success { get; set; }
        public int id { get; set; }
        public string username { get; set; }
    }


    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext context;

        public LoginController(AppDbContext appDbContext)
        {
            context = appDbContext;

            if (context.User.Count() == 0)
            {
                var password = PasswordHash.HashPassword("123456");
                context.User.Add(new eCommerceNetCore.Models.User { username = "Harshit" , email = "hp@gmail.com", password = password , phone = "5197221234" });
                context.User.Add(new eCommerceNetCore.Models.User { username = "John", email = "john@gmail.com", password = password, phone = "5197221255" });
                context.SaveChanges();
            }
        }

        // GET: api/Login
        [HttpGet]
        public async Task<List<User>> Get()
        {
            return await context.User.ToListAsync();
        }

        // GET: api/Login/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<User>> Get(int id)
        {
            return await context.User.FindAsync(id);
        }

        // POST: api/Login
        [HttpPost]
        public async Task<Response> Login([FromBody] Login login)
        {
            var r = new Response { Success = false};
            //see if email matches a user
            User user = await context.User.SingleOrDefaultAsync(u => u.email == login.Email);
            if (user != null)
                r.Success = PasswordHash.VerifyHashedPassword(user.password, login.Password);

            if (r.Success)
            {
                await HttpContext.Session.LoadAsync();
                HttpContext.Session.SetInt32("userId", user.id);
                await HttpContext.Session.CommitAsync();

                r.id = user.id;
                r.username = user.username;
            }

            return r;
        }

        // PUT: api/Login/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, User model)
        {
            var exists = await context.User.AnyAsync(f => f.id == id);
            if (!exists)
            {
                return NotFound();
            }

            context.User.Update(model);
            await context.SaveChangesAsync();
            return Ok();

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var entity = await context.User.FindAsync(id);

            context.User.Remove(entity);

            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
