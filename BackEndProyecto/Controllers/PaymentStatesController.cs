using BackEndProyecto.Context;
using BackEndProyecto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace BackEndProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentStatesController : ControllerBase
    {
        private readonly dbcontextBank _context;

        public PaymentStatesController(dbcontextBank context)
        {
            _context = context;
        }

        // GET: api/PaymentStates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentStates>>> GetPaymentStates()
        {
            // Obtener todos los estados de pago que no estén eliminados
            return await _context.PaymentStates
                                 .Where(p => !p.IsDeleted)
                                 .ToListAsync();
        }

        // GET: api/PaymentStates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentStates>> GetPaymentState(int id)
        {
            var paymentState = await _context.PaymentStates.FindAsync(id);

            if (paymentState == null || paymentState.IsDeleted)
            {
                return NotFound();
            }

            return paymentState;
        }

        // POST: api/PaymentStates
        [HttpPost]
        public async Task<ActionResult<PaymentStates>> PostPaymentState(PaymentStates paymentState)
        {
            _context.PaymentStates.Add(paymentState);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPaymentState), new { id = paymentState.PaymentStateId }, paymentState);
        }

        // PUT: api/PaymentStates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentState(int id, PaymentStates paymentState)
        {
            if (id != paymentState.PaymentStateId)
            {
                return BadRequest();
            }

            _context.Entry(paymentState).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentStateExists(id))
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

        // DELETE: api/PaymentStates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentState(int id)
        {
            var paymentState = await _context.PaymentStates.FindAsync(id);

            if (paymentState == null || paymentState.IsDeleted)
            {
                return NotFound();
            }

            // Marcar IsDeleted como true en lugar de eliminar físicamente
            paymentState.IsDeleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Método auxiliar para verificar si un estado de pago existe
        private bool PaymentStateExists(int id)
        {
            return _context.PaymentStates.Any(p => p.PaymentStateId == id && !p.IsDeleted);
        }
    }

}
