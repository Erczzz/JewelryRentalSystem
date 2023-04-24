using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JewelryRentalSystemAPI.DTO;
using JewelryRentalSystemAPI.Models;
using JewelryRentalSystemAPI.Data;

namespace JewelryRentalSystemAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly JRSDBContext _context;

        public TransactionsController(JRSDBContext context)
        {
            _context = context;
        }

        // GET: api/Transactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionDto>>> GetTransactions()
        {
            var transactions = await _context.Transactions
                .Include(t => t.Appointment)
                .ToListAsync();

            return Ok(transactions.Select(t => new TransactionDto
            {
                TransactionId = t.TransactionId,
                AppointmentId = t.AppointmentId
            }));
        }

        // GET: api/Transactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionDto>> GetTransaction(int id)
        {
            var transaction = await _context.Transactions
                .Include(t => t.Appointment)
                .FirstOrDefaultAsync(t => t.TransactionId == id);

            if (transaction == null)
            {
                return NotFound();
            }

            var transactionDto = new TransactionDto
            {
                TransactionId = transaction.TransactionId,
                AppointmentId = transaction.AppointmentId
            };

            return Ok(transactionDto);
        }

        // POST: api/Transactions
        [HttpPost]
        public async Task<ActionResult<TransactionDto>> CreateTransaction(TransactionDto transactionDto)
        {
            var transaction = new Transaction
            {
                AppointmentId = transactionDto.AppointmentId
            };

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            transactionDto.TransactionId = transaction.TransactionId;

            return CreatedAtAction(nameof(GetTransaction), new { id = transactionDto.TransactionId }, transactionDto);
        }

        // PUT: api/Transactions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransaction(int id, TransactionDto transactionDto)
        {
            if (id != transactionDto.TransactionId)
            {
                return BadRequest();
            }

            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }

            transaction.AppointmentId = transactionDto.AppointmentId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionExists(id))
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

        // DELETE: api/Transactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }

            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransactionExists(int id)
        {
            return _context.Transactions.Any(e => e.TransactionId == id);
        }

    }
}
