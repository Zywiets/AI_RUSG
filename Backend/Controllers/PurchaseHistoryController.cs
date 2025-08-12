using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;
using Backend.DTOs;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public PurchaseHistoryController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/PurchaseHistory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseHistoryDto>>> GetPurchaseHistories()
        {
            var purchases = await _context.PurchaseHistories
                .Include(p => p.User)
                .ToListAsync();
            return Ok(_mapper.Map<IEnumerable<PurchaseHistoryDto>>(purchases));
        }

        // GET: api/PurchaseHistory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseHistoryDto>> GetPurchaseHistory(int id)
        {
            var purchaseHistory = await _context.PurchaseHistories
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (purchaseHistory == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PurchaseHistoryDto>(purchaseHistory));
        }

        // GET: api/PurchaseHistory/user/5
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<PurchaseHistoryDto>>> GetPurchaseHistoryByUser(int userId)
        {
            var purchases = await _context.PurchaseHistories
                .Where(p => p.UserId == userId)
                .Include(p => p.User)
                .ToListAsync();
            return Ok(_mapper.Map<IEnumerable<PurchaseHistoryDto>>(purchases));
        }

        // POST: api/PurchaseHistory
        [HttpPost]
        public async Task<ActionResult<PurchaseHistoryDto>> PostPurchaseHistory(CreatePurchaseHistoryDto createPurchaseHistoryDto)
        {
            var purchaseHistory = _mapper.Map<PurchaseHistory>(createPurchaseHistoryDto);
            _context.PurchaseHistories.Add(purchaseHistory);
            await _context.SaveChangesAsync();

            var purchaseHistoryDto = _mapper.Map<PurchaseHistoryDto>(purchaseHistory);
            return CreatedAtAction("GetPurchaseHistory", new { id = purchaseHistory.Id }, purchaseHistoryDto);
        }

        // PUT: api/PurchaseHistory/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchaseHistory(int id, UpdatePurchaseHistoryDto updatePurchaseHistoryDto)
        {
            var purchaseHistory = await _context.PurchaseHistories.FindAsync(id);
            if (purchaseHistory == null)
            {
                return NotFound();
            }

            _mapper.Map(updatePurchaseHistoryDto, purchaseHistory);

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