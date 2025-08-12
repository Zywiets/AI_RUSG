using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseHistoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PurchaseHistoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PurchaseHistory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseHistory>>> GetPurchaseHistories()
        {
            return await _context.PurchaseHistories
                .Include(p => p.User)
                .ToListAsync();
        }

        // GET: api/PurchaseHistory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseHistory>> GetPurchaseHistory(int id)
        {
            var purchaseHistory = await _context.PurchaseHistories
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (purchaseHistory == null)
            {
                return NotFound();
            }

            return purchaseHistory;
        }

        // GET: api/PurchaseHistory/user/5
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<PurchaseHistory>>> GetPurchaseHistoryByUser(int userId)
        {
            return await _context.PurchaseHistories
                .Where(p => p.UserId == userId)
                .Include(p => p.User)
                .ToListAsync();
        }

        // POST: api/PurchaseHistory
        [HttpPost]
        public async Task<ActionResult<PurchaseHistory>> PostPurchaseHistory(PurchaseHistory purchaseHistory)
        {
            _context.PurchaseHistories.Add(purchaseHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPurchaseHistory", new { id = purchaseHistory.Id }, purchaseHistory);
        }

        // PUT: api/PurchaseHistory/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchaseHistory(int id, PurchaseHistory purchaseHistory)
        {
            if (id != purchaseHistory.Id)
            {
                return BadRequest();
            }

            _context.Entry(purchaseHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseHistoryExists(id))
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

        // DELETE: api/PurchaseHistory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchaseHistory(int id)
        {
            var purchaseHistory = await _context.PurchaseHistories.FindAsync(id);
            if (purchaseHistory == null)
            {
                return NotFound();
            }

            _context.PurchaseHistories.Remove(purchaseHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PurchaseHistoryExists(int id)
        {
            return _context.PurchaseHistories.Any(e => e.Id == id);
        }
    }
}