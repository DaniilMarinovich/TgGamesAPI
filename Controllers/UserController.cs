using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandomTgAPI.DBContexts;
using RandomTgAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomTgAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;

        public UserController(UserContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet]
        [Route("GetUserById/{id}")]
        public async Task<ActionResult<User>> GetUserById(long id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // GET: api/User/GetUserByUsername/{username}
        [HttpGet]
        [Route("GetUserByUsername/{username}")]
        public async Task<ActionResult<User>> GetUserByUsername(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // GET: api/User/GetUserIdByUsername/{username}
        [HttpGet]
        [Route("GetUserIdByUsername/{username}")]
        public async Task<ActionResult<long>> GetUserIdByUsername(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);

            if (user == null)
            {
                return NotFound();
            }

            return user.Id;
        }

        // GET: api/User/GetUsernameById/{id}
        [HttpGet]
        [Route("GetUsernameById/{id}")]
        public async Task<ActionResult<string>> GetUsernameById(long id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user.UserName;
        }

        // POST: api/User
        [HttpPost]
        [Route("CreateUser")]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        // PUT: api/User/5
        [HttpPut]
        [Route("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser(long id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // DELETE: api/User/5
        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(long id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
