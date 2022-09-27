using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly BlogContext _context;

        public GameController(BlogContext context)
        {
            _context = context;
        }

        // GET: api/Game
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetGames()
        {
          if (_context.Games == null)
          {
              return NotFound();
          }
            return await _context.Games.ToListAsync();
        }

        // // GET: api/Game/5
        // [HttpGet("{id}")]
        // public async Task<ActionResult<Game>> GetGame(long id)
        // {
        //   if (_context.Games == null)
        //   {
        //       return NotFound();
        //   }
        //     var game = await _context.Games.FindAsync(id);

        //     if (game == null)
        //     {
        //         return NotFound();
        //     }

        //     return game;
        // }

        // // PUT: api/Game/5
        // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutGame(long id, Game game)
        // {
        //     if (id != game.Id)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(game).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!GameExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return NoContent();
        // }

        // // POST: api/Game
        // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // public async Task<ActionResult<Game>> PostGame(Game game)
        // {
        //   if (_context.Games == null)
        //   {
        //       return Problem("Entity set 'BlogContext.Games'  is null.");
        //   }
        //     _context.Games.Add(game);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("GetGame", new { id = game.Id }, game);
        // }

        // // DELETE: api/Game/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteGame(long id)
        // {
        //     if (_context.Games == null)
        //     {
        //         return NotFound();
        //     }
        //     var game = await _context.Games.FindAsync(id);
        //     if (game == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Games.Remove(game);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        // private bool GameExists(long id)
        // {
        //     return (_context.Games?.Any(e => e.Id == id)).GetValueOrDefault();
        // }
    }
}
