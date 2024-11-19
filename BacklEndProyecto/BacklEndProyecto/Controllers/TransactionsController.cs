using BacklEndProyecto.Models;
using BacklEndProyecto.Services;
using Microsoft.AspNetCore.Mvc;

namespace BacklEndProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionsService _transactionsService;

        public TransactionsController(ITransactionsService transactionsService)
        {
            _transactionsService = transactionsService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Transactions>>> GetAllTransactions()
        {
            var transactions = await _transactionsService.GetAllTransactionsAsync();
            return Ok(transactions);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Transactions>> GetTransactionById(int id)
        {
            var transaction = await _transactionsService.GetTransactionByIdAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return Ok(transaction);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateTransaction([FromBody] int tTypeid, int aOrigin, 
            int aDestination, int value, DateTime tDate, string tDescription, bool isDeleted)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Transactions transaction = new Transactions
            { 
                TransactionTypeId = tTypeid,
                AccountOrigin = aOrigin,
                AccountDestination = aDestination,
                Value = value,
                TransactionDate = tDate,
                TransactionDescrition = tDescription,
                IsDeleted = isDeleted,
                TransactionTypes = null
            };

            await _transactionsService.CreateTransactionAsync(transaction);
            return CreatedAtAction(nameof(GetTransactionById), new { id = transaction.TransactionId }, transaction);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateTransaction(int id, [FromBody] int tTypeid, int aOrigin,
            int aDestination, int value, DateTime tDate, string tDescription, bool isDeleted)
        {
            var existingTransaction = await _transactionsService.GetTransactionByIdAsync(id);
            if (existingTransaction == null)
            {
                return NotFound();
            }

            existingTransaction.TransactionTypeId = tTypeid;
            existingTransaction.AccountOrigin =aOrigin;
            existingTransaction.AccountDestination =aDestination;
            existingTransaction.Value = value;
            existingTransaction.TransactionDate = tDate;
            existingTransaction.TransactionDescrition = tDescription;
            existingTransaction.IsDeleted = isDeleted;

            await _transactionsService.UpdateTransactionAsync(existingTransaction);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            var transaction = await _transactionsService.GetTransactionByIdAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }

            await _transactionsService.DeleteTransactionAsync(id);
            return NoContent();
        }
    }

}
