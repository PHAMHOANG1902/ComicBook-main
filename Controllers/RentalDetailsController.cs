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
    public class RentalDetailController : ControllerBase
    {
        private readonly ComicSystemContext _context;

        public RentalDetailController(ComicSystemContext context)
        {
            _context = context;
        }

        // GET: api/RentalDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentalDetail>>> GetRentalDetails()
        {
            return await _context.RentalDetails.Include(rd => rd.ComicBook).Include(rd => rd.Rental).ToListAsync();
        }

        // GET: api/RentalDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RentalDetail>> GetRentalDetail(int id)
        {
            var rentalDetail = await _context.RentalDetails.Include(rd => rd.ComicBook).Include(rd => rd.Rental)
                .FirstOrDefaultAsync(rd => rd.RentalDetailID == id);

            if (rentalDetail == null)
            {
                return NotFound();
            }

            return rentalDetail;
        }

        // POST: api/RentalDetail
        [HttpPost]
        public async Task<ActionResult<RentalDetail>> PostRentalDetail(RentalDetail rentalDetail)
        {
            _context.RentalDetails.Add(rentalDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRentalDetail), new { id = rentalDetail.RentalDetailID }, rentalDetail);
        }

        // PUT: api/RentalDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRentalDetail(int id, RentalDetail rentalDetail)
        {
            if (id != rentalDetail.RentalDetailID)
            {
                return BadRequest();
            }

            _context.Entry(rentalDetail).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/RentalDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRentalDetail(int id)
        {
            var rentalDetail = await _context.RentalDetails.FindAsync(id);
            if (rentalDetail == null)
            {
                return NotFound();
            }

            _context.RentalDetails.Remove(rentalDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
