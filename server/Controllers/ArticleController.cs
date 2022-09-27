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
    public class ArticleController : ControllerBase
    {
        private readonly BlogContext _context;

        public ArticleController(BlogContext context)
        {
            _context = context;
        }

        // GET: api/Article
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticles()
        {
            if (_context.Articles == null)
            {
                return NotFound();
            }
            return await _context.Articles.Where(m=>m.DeleteFlag==0).ToListAsync();
        }

        // GET: api/Article/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> GetArticle(long id)
        {
            if (_context.Articles == null)
            {
                return NotFound();
            }
            var article = await _context.Articles.FindAsync(id);

            if (article == null)
            {
                return NotFound();
            }
            
            if (article.AuthorIp != GetUserIp())
            {
                return Problem("You are not the author of this article.");
            }

            return article;
        }

        // PUT: api/Article/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticle(long id, Article article)
        {
	    var db_article = await _context.Articles.FindAsync(id);

	    if (db_article == null)
	    {
		return NotFound();
	    }

            if (db_article.AuthorIp != GetUserIp())
            {
                return Problem("You are not the author of this article.");
            }
            
            db_article.Title = article.Title;
            db_article.Author = article.Author;
            db_article.Content = article.Content;

            _context.Entry(db_article).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleExists(id))
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

        // POST: api/Article
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Article>> PostArticle(Article article)
        {
            if (_context.Articles == null)
            {
                return Problem("Entity set 'BlogContext.Articles'  is null.");
            }
            article.AuthorIp = GetUserIp();
            _context.Articles.Add(article);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArticle", new { id = article.Id }, article);
        }

        // DELETE: api/Article/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(long id)
        {
            if (_context.Articles == null)
            {
                return NotFound();
            }
            var article = await _context.Articles.FindAsync(id);
            
            if (article == null)
            {
                return NotFound();
            }

            if (article.AuthorIp != GetUserIp())
            {
                return Problem("You are not the author of this article.");
            }

            article.DeleteFlag = 1;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArticleExists(long id)
        {
            return (_context.Articles?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private string GetUserIp()
        {
            System.Console.WriteLine($"X-Forwarded-For: {HttpContext.Request.Headers["X-Forwarded-For"]}");
            return HttpContext.Request.Headers["X-Forwarded-For"].ToString().Split(',').First();
        }
    }
}
