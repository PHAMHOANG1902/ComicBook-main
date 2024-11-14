using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ComicSystemAPI.Data;
using ComicSystemAPI.Models;

namespace ComicSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComicBooksController : ControllerBase
    {
        private readonly ComicSystemContext _context;

        public ComicBooksController(ComicSystemContext context)
        {
            _context = context;
        }

        // GET: api/ComicBooks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComicBook>>> GetComicBooks()
        {
            return await _context.ComicBooks.ToListAsync();
        }

        // GET: api/ComicBooks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComicBook>> GetComicBook(int id)
        {
            var comicBook = await _context.ComicBooks.FindAsync(id);

            if (comicBook == null)
            {
                return NotFound();
            }

            return comicBook;
        }

        // POST: api/ComicBooks
        [HttpPost]
        public async Task<ActionResult<ComicBook>> PostComicBook(ComicBook comicBook)
        {
            _context.ComicBooks.Add(comicBook);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetComicBook), new { id = comicBook.ComicBookID }, comicBook);
        }

        // PUT: api/ComicBooks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComicBook(int id, ComicBook comicBook)
        {
            if (id != comicBook.ComicBookID)
            {
                return BadRequest();
            }

            _context.Entry(comicBook).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/ComicBooks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComicBook(int id)
        {
            var comicBook = await _context.ComicBooks.FindAsync(id);
            if (comicBook == null)
            {
                return NotFound();
            }

            _context.ComicBooks.Remove(comicBook);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
