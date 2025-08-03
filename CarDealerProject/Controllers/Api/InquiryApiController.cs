using CarDealerProject.Data;
using CarDealerProject.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarDealerProject.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class InquiryApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InquiryApiController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Inquiry
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inquiry>>> GetInquiries()
        {
            return await _context.Inquiries.Include(i => i.Car).ToListAsync();
        }

        // GET: api/Inquiry/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Inquiry>> GetInquiry(int id)
        {
            var inquiry = await _context.Inquiries
                .Include(i => i.Car)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (inquiry == null)
                return NotFound();

            return inquiry;
        }

        // POST: api/Inquiry
        [HttpPost]
        public async Task<ActionResult<Inquiry>> PostInquiry(Inquiry inquiry)
        {
            _context.Inquiries.Add(inquiry);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInquiry), new { id = inquiry.Id }, inquiry);
        }

        // DELETE: api/Inquiry/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInquiry(int id)
        {
            var inquiry = await _context.Inquiries.FindAsync(id);
            if (inquiry == null)
                return NotFound();

            _context.Inquiries.Remove(inquiry);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

