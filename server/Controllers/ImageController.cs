using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly BlogContext _context;

        public ImageController(BlogContext context)
        {
            _context = context;
        }

        // GET: api/Image
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Image>>> GetImages()
        {
          if (_context.Images == null)
          {
              return NotFound();
          }
            return await _context.Images.ToListAsync();
        }

        // // GET: api/Image/5
        // [HttpGet("{id}")]
        // public async Task<ActionResult<Image>> GetImage(long id)
        // {
        //   if (_context.Images == null)
        //   {
        //       return NotFound();
        //   }
        //     var image = await _context.Images.FindAsync(id);

        //     if (image == null)
        //     {
        //         return NotFound();
        //     }

        //     return image;
        // }

        // // PUT: api/Image/5
        // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutImage(long id, Image image)
        // {
        //     if (id != image.Id)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(image).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!ImageExists(id))
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

        // // POST: api/Image
        // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // public async Task<ActionResult<Image>> PostImage(Image image)
        // {
        //   if (_context.Images == null)
        //   {
        //       return Problem("Entity set 'BlogContext.Images'  is null.");
        //   }
        //     _context.Images.Add(image);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("GetImage", new { id = image.Id }, image);
        // }

        // // DELETE: api/Image/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteImage(long id)
        // {
        //     if (_context.Images == null)
        //     {
        //         return NotFound();
        //     }
        //     var image = await _context.Images.FindAsync(id);
        //     if (image == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Images.Remove(image);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        // private bool ImageExists(long id)
        // {
        //     return (_context.Images?.Any(e => e.Id == id)).GetValueOrDefault();
        // }
    }
}
