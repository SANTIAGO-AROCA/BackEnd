namespace BackEndProyecto.Controllers
{
    using BackEndProyecto.Context;
    using BackEndProyecto.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class TransactionTypesController : ControllerBase
    {
        private readonly dbcontextBank _context;

        public TransactionTypesController(dbcontextBank context)
        {
            _context = context;
        }

        // GET: api/TransactionTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionTypes>>> GetTransactionTypes()
        {
            return await _context.TransactionTypes
                                 .Where(tt => !tt.IsDeleted) // Filtrar tipos de transacción eliminados
                                 .ToListAsync();
        }

        // GET: api/TransactionTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionTypes>> GetTransactionType(int id)
        {
            var transactionType = await _context.TransactionTypes.FindAsync(id);

            if (transactionType == null || transactionType.IsDeleted)
            {
                return NotFound();
            }

            return transactionType;
        }

        // POST: api/TransactionTypes
        [HttpPost]
        public async Task<ActionResult<TransactionTypes>> PostTransactionType(TransactionTypes transactionType)
        {
            _context.TransactionTypes.Add(transactionType);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTransactionType), new { id = transactionType.TransactionTypeId }, transactionType);
        }

        // PUT: api/TransactionTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransactionType(int id, TransactionTypes transactionType)
        {
            if (id != transactionType.TransactionTypeId)
            {
                return BadRequest();
            }

            // Verifica que el tipo de transacción exista
            var existingTransactionType = await _context.TransactionTypes.FindAsync(id);
            if (existingTransactionType == null || existingTransactionType.IsDeleted)
            {
                return NotFound();
            }

            // Actualizar campos relevantes
            existingTransactionType.TransactionTypeNames = transactionType.TransactionTypeNames;
            existingTransactionType.Description = transactionType.Description;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/TransactionTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransactionType(int id)
        {
            var transactionType = await _context.TransactionTypes.FindAsync(id);

            if (transactionType == null || transactionType.IsDeleted)
            {
                return NotFound();
            }

            // Marcar IsDeleted como true en lugar de eliminar físicamente
            transactionType.IsDeleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
