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
    public class UserGameController : ControllerBase
    {
        private readonly UserContext _context;

        public UserGameController(UserContext context)
        {
            _context = context;
        }

        // GET: api/UserGame
        [HttpGet]
        [Route("GetAllUserGames")]
        public async Task<ActionResult<IEnumerable<UserGame>>> GetAllUserGames()
        {
            return await _context.UserGames.ToListAsync();
        }

        // GET: api/UserGame/5
        [HttpGet]
        [Route("GetUserGameById/{id}")]
        public async Task<ActionResult<UserGame>> GetUserGameById(long id)
        {
            var userGame = await _context.UserGames.FindAsync(id);

            if (userGame == null)
            {
                return NotFound();
            }

            return userGame;
        }

        // POST: api/UserGame
        [HttpPost]
        [Route("CreateUserGame")]
        public async Task<ActionResult<UserGame>> CreateUserGame(UserGame userGame)
        {
            _context.UserGames.Add(userGame);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserGameById), new { id = userGame.Id }, userGame);
        }

        // PUT: api/UserGame/5
        [HttpPut]
        [Route("UpdateUserGame/{id}")]
        public async Task<IActionResult> UpdateUserGame(long id, UserGame userGame)
        {
            if (id != userGame.Id)
            {
                return BadRequest();
            }

            _context.Entry(userGame).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserGameExists(id))
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

        // DELETE: api/UserGame/5
        [HttpDelete]
        [Route("DeleteUserGame/{id}")]
        public async Task<IActionResult> DeleteUserGame(long id)
        {
            var userGame = await _context.UserGames.FindAsync(id);
            if (userGame == null)
            {
                return NotFound();
            }

            _context.UserGames.Remove(userGame);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserGameExists(long id)
        {
            return _context.UserGames.Any(e => e.Id == id);
        }
    }
}
