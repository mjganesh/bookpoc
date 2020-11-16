using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Book.Data.DBContext;
using Book.Model.DataModel;
using Microsoft.AspNetCore.Authorization;
using Book.Model;

namespace Book.API.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class BookDetailsController : ControllerBase
    {
        private readonly BookContext _context;

        public BookDetailsController(BookContext context)
        {
            _context = context;
        }

        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.User)]
        // GET: api/BookDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDetails>>> GetBook()
        {
            return await _context.BookDetails.ToListAsync();
        }

        // GET: api/BookDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDetails>> GetBookDetails(int id)
        {
            var bookDetails = await _context.BookDetails.FindAsync(id);

            if (bookDetails == null)
            {
                return NotFound();
            }

            return bookDetails;
        }

        // PUT: api/BookDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookDetails(int id, BookDetails bookDetails)
        {
            if (id != bookDetails.BookId)
            {
                return BadRequest();
            }

            _context.Entry(bookDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookDetailsExists(id))
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

        // POST: api/BookDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BookDetails>> PostBookDetails(BookDetails bookDetails)
        {
            _context.BookDetails.Add(bookDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookDetails", new { id = bookDetails.BookId }, bookDetails);
        }

        // DELETE: api/BookDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookDetails>> DeleteBookDetails(int id)
        {
            var bookDetails = await _context.BookDetails.FindAsync(id);
            if (bookDetails == null)
            {
                return NotFound();
            }

            _context.BookDetails.Remove(bookDetails);
            await _context.SaveChangesAsync();

            return bookDetails;
        }

        private bool BookDetailsExists(int id)
        {
            return _context.BookDetails.Any(e => e.BookId == id);
        }
    }
}
