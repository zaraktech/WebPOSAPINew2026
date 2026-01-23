using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTypesController : ControllerBase
    {
        private readonly AppDBContext _context;

        public PaymentTypesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/PaymentTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentTypes>>> GetPaymentTypes()
        {
            return await _context.PaymentTypes.ToListAsync();
        }

        // GET: api/PaymentTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentTypes>> GetPaymentTypes(int id)
        {
            var paymentTypes = await _context.PaymentTypes.FindAsync(id);

            if (paymentTypes == null)
            {
                return NotFound();
            }

            return paymentTypes;
        }

        // PUT: api/PaymentTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentTypes(int id, PaymentTypes paymentTypes)
        {
            if (id != paymentTypes.PaymentId)
            {
                return BadRequest();
            }

            _context.Entry(paymentTypes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentTypesExists(id))
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

        // POST: api/PaymentTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentTypes>> PostPaymentTypes(PaymentTypes paymentTypes)
        {
            _context.PaymentTypes.Add(paymentTypes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentTypes", new { id = paymentTypes.PaymentId }, paymentTypes);
        }

        // DELETE: api/PaymentTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentTypes(int id)
        {
            var paymentTypes = await _context.PaymentTypes.FindAsync(id);
            if (paymentTypes == null)
            {
                return NotFound();
            }

            _context.PaymentTypes.Remove(paymentTypes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentTypesExists(int id)
        {
            return _context.PaymentTypes.Any(e => e.PaymentId == id);
        }
    }
}
