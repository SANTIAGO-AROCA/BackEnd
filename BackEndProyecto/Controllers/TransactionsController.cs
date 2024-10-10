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
    public class TransactionsController : ControllerBase
    {
        private readonly dbcontextBank _context;

        public TransactionsController(dbcontextBank context)
        {
            _context = context;
        }

        // GET: api/Transactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transactions>>> GetTransactions()
        {
            return await _context.Transactions
                                 .Include(t => t.TransactionTypes) // Cargar tipo de transacción
                                 .Where(t => !t.IsDeleted) // Filtrar transacciones eliminadas
                                 .ToListAsync();
        }

        // GET: api/Transactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transactions>> GetTransaction(int id)
        {
            var transaction = await _context.Transactions
                                             .Include(t => t.TransactionTypes) // Cargar tipo de transacción
                                             .FirstOrDefaultAsync(t => t.TransactionId == id && !t.IsDeleted);

            if (transaction == null)
            {
                return NotFound();
            }

            return transaction;
        }

        // POST: api/Transactions
        [HttpPost]
        public async Task<ActionResult<Transactions>> PostTransaction(Transactions transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTransaction), new { id = transaction.TransactionId }, transaction);
        }

        // PUT: api/Transactions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransaction(int id, Transactions transaction)
        {
            if (id != transaction.TransactionId)
            {
                return BadRequest();
            }

            // Verifica que la transacción exista
            var existingTransaction = await _context.Transactions.FindAsync(id);
            if (existingTransaction == null || existingTransaction.IsDeleted)
            {
                return NotFound();
            }

            // Actualizar campos relevantes
            existingTransaction.TransactionTypeId = transaction.TransactionTypeId;
            existingTransaction.AccountOrigin = transaction.AccountOrigin;
            existingTransaction.AccountDestination = transaction.AccountDestination;
            existingTransaction.Value = transaction.Value;
            existingTransaction.TransactionDate = transaction.TransactionDate;
            existingTransaction.TransactionDescrition = transaction.TransactionDescrition;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Transactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);

            if (transaction == null || transaction.IsDeleted)
            {
                return NotFound();
            }

            // Marcar IsDeleted como true en lugar de eliminar físicamente
            transaction.IsDeleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
