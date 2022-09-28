using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly BlogContext _context;

        public MusicController(BlogContext context)
        {
            _context = context;
        }

        // GET: api/Music
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Music>>> GetMusics()
        {
          if (_context.Musics == null)
          {
              return NotFound();
          }
            return await _context.Musics.ToListAsync();
        }

        // // GET: api/Music/5
        // [HttpGet("{id}")]
        // public async Task<ActionResult<Music>> GetMusic(long id)
        // {
        //   if (_context.Musics == null)
        //   {
        //       return NotFound();
        //   }
        //     var music = await _context.Musics.FindAsync(id);

        //     if (music == null)
        //     {
        //         return NotFound();
        //     }

        //     return music;
        // }

        // // PUT: api/Music/5
        // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutMusic(long id, Music music)
        // {
        //     if (id != music.Id)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(music).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!MusicExists(id))
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

        // // POST: api/Music
        // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // public async Task<ActionResult<Music>> PostMusic(Music music)
        // {
        //   if (_context.Musics == null)
        //   {
        //       return Problem("Entity set 'BlogContext.Musics'  is null.");
        //   }
        //     _context.Musics.Add(music);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("GetMusic", new { id = music.Id }, music);
        // }

        // // DELETE: api/Music/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteMusic(long id)
        // {
        //     if (_context.Musics == null)
        //     {
        //         return NotFound();
        //     }
        //     var music = await _context.Musics.FindAsync(id);
        //     if (music == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Musics.Remove(music);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        // private bool MusicExists(long id)
        // {
        //     return (_context.Musics?.Any(e => e.Id == id)).GetValueOrDefault();
        // }
    }
}
