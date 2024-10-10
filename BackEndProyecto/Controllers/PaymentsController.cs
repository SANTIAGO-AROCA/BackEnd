using BackEndProyecto.Context;
using BackEndProyecto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace BackEndProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly dbcontextBank _context;

        public PaymentsController(dbcontextBank context)
        {
            _context = context;
        }

        // GET: api/Payments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payments>>> GetPayments()
        {
            // Obtener todos los pagos que no estén eliminados
            return await _context.Payments
                                 .Where(p => !p.IsDeleted)
                                 .Include(p => p.PaymentMethodsTypes)
                                 .Include(p => p.PaymentStates)
                                 .ToListAsync();
        }

        // GET: api/Payments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Payments>> GetPayment(int id)
        {
            var payment = await _context.Payments
                                        .Include(p => p.PaymentMethodsTypes)
                                        .Include(p => p.PaymentStates)
                                        .FirstOrDefaultAsync(p => p.PaymentId == id && !p.IsDeleted);

            if (payment == null)
            {
                return NotFound();
            }

            return payment;
        }

        // POST: api/Payments
        [HttpPost]
        public async Task<ActionResult<Payments>> PostPayment(Payments payment)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPayment), new { id = payment.PaymentId }, payment);
        }

        // PUT: api/Payments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayment(int id, Payments payment)
        {
            if (id != payment.PaymentId)
            {
                return BadRequest();
            }

            _context.Entry(payment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentExists(id))
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

        // DELETE: api/Payments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            var payment = await _context.Payments.FindAsync(id);

            if (payment == null || payment.IsDeleted)
            {
                return NotFound();
            }

            // Marcar IsDeleted como true en lugar de eliminar físicamente
            payment.IsDeleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Método auxiliar para verificar si un pago existe
        private bool PaymentExists(int id)
        {
            return _context.Payments.Any(p => p.PaymentId == id && !p.IsDeleted);
        }
    }

}
