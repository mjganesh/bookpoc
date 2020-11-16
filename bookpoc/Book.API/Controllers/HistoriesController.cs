using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Book.Data.DBContext;
using Book.Data.DataModel;
using Microsoft.AspNetCore.Authorization;
using Book.Model;

namespace Book.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = UserRoles.User)]
    [ApiController]
    public class HistoriesController : ControllerBase
    {
        private readonly BookContext _context;

        public HistoriesController(BookContext context)
        {
            _context = context;
        }

        // GET: api/Histories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<History>>> GetHistory()
        {
            return await _context.History.ToListAsync();
        }

        // GET: api/Histories/5
        [HttpGet("{userId}")]
        [Authorize(Roles = UserRoles.User)]
        public async Task<ActionResult<History>> GetReviewsByuserId(string userId)
        {
            var history = await _context.History.FirstOrDefaultAsync(x => x.UserId == userId);

            if (history== null)
            {
                return NotFound();
            }

            return history;
        }

        // GET: api/Histories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<History>> GetHistory(int id)
        {
            var history = await _context.History.FindAsync(id);

            if (history == null)
            {
                return NotFound();
            }

            return history;
        }

        // PUT: api/Histories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistory(int id, History history)
        {
            if (id != history.ReviewId)
            {
                return BadRequest();
            }

            _context.Entry(history).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoryExists(id))
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

        // POST: api/Histories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<History>> PostHistory(History history)
        {
            _context.History.Add(history);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistory", new { id = history.ReviewId }, history);
        }

        // DELETE: api/Histories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<History>> DeleteHistory(int id)
        {
            var history = await _context.History.FindAsync(id);
            if (history == null)
            {
                return NotFound();
            }

            _context.History.Remove(history);
            await _context.SaveChangesAsync();

            return history;
        }

        private bool HistoryExists(int id)
        {
            return _context.History.Any(e => e.ReviewId == id);
        }
    }
}
