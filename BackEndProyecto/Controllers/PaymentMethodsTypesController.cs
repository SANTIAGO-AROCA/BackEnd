using BackEndProyecto.Context;
using BackEndProyecto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace BackEndProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodsTypesController : ControllerBase
    {
        private readonly dbcontextBank _context;

        public PaymentMethodsTypesController(dbcontextBank context)
        {
            _context = context;
        }

        // GET: api/PaymentMethodsTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentMethodsTypes>>> GetPaymentMethodsTypes()
        {
            // Obtener todos los métodos de pago que no estén eliminados
            return await _context.PaymentMethodsTypes
                                 .Where(p => !p.IsDeleted)
                                 .ToListAsync();
        }

        // GET: api/PaymentMethodsTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentMethodsTypes>> GetPaymentMethodsType(int id)
        {
            var paymentMethodType = await _context.PaymentMethodsTypes.FindAsync(id);

            if (paymentMethodType == null || paymentMethodType.IsDeleted)
            {
                return NotFound();
            }

            return paymentMethodType;
        }

        // POST: api/PaymentMethodsTypes
        [HttpPost]
        public async Task<ActionResult<PaymentMethodsTypes>> PostPaymentMethodsType(PaymentMethodsTypes paymentMethodType)
        {
            _context.PaymentMethodsTypes.Add(paymentMethodType);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPaymentMethodsType), new { id = paymentMethodType.PaymentMethodId }, paymentMethodType);
        }

        // PUT: api/PaymentMethodsTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentMethodsType(int id, PaymentMethodsTypes paymentMethodType)
        {
            if (id != paymentMethodType.PaymentMethodId)
            {
                return BadRequest();
            }

            _context.Entry(paymentMethodType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentMethodTypeExists(id))
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

        // DELETE: api/PaymentMethodsTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentMethodsType(int id)
        {
            var paymentMethodType = await _context.PaymentMethodsTypes.FindAsync(id);

            if (paymentMethodType == null || paymentMethodType.IsDeleted)
            {
                return NotFound();
            }

            // Marcar IsDeleted como true en lugar de eliminar físicamente
            paymentMethodType.IsDeleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Método auxiliar para verificar si un método de pago existe
        private bool PaymentMethodTypeExists(int id)
        {
            return _context.PaymentMethodsTypes.Any(p => p.PaymentMethodId == id && !p.IsDeleted);
        }
    }

}
