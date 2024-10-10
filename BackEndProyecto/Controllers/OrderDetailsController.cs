using BackEndProyecto.Context;
using BackEndProyecto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace BackEndProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly dbcontextBank _context;

        public OrderDetailsController(dbcontextBank context)
        {
            _context = context;
        }

        // GET: api/OrderDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetails>>> GetOrderDetails()
        {
            // Obtener todos los detalles de pedidos que no estén eliminados
            return await _context.OrderDetails
                                 .Where(o => !o.IsDeleted)
                                 .ToListAsync();
        }

        // GET: api/OrderDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetails>> GetOrderDetails(int id)
        {
            var orderDetails = await _context.OrderDetails.FindAsync(id);

            if (orderDetails == null || orderDetails.IsDeleted)
            {
                return NotFound();
            }

            return orderDetails;
        }

        // POST: api/OrderDetails
        [HttpPost]
        public async Task<ActionResult<OrderDetails>> PostOrderDetails(OrderDetails orderDetails)
        {
            _context.OrderDetails.Add(orderDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrderDetails), new { id = orderDetails.OrderDetailsId }, orderDetails);
        }

        // PUT: api/OrderDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderDetails(int id, OrderDetails orderDetails)
        {
            if (id != orderDetails.OrderDetailsId)
            {
                return BadRequest();
            }

            _context.Entry(orderDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderDetailsExists(id))
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

        // DELETE: api/OrderDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetails(int id)
        {
            var orderDetails = await _context.OrderDetails.FindAsync(id);

            if (orderDetails == null || orderDetails.IsDeleted)
            {
                return NotFound();
            }

            // Marcar IsDeleted como true en lugar de eliminar físicamente
            orderDetails.IsDeleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Método auxiliar para verificar si existen detalles de pedidos
        private bool OrderDetailsExists(int id)
        {
            return _context.OrderDetails.Any(o => o.OrderDetailsId == id && !o.IsDeleted);
        }
    }

}
