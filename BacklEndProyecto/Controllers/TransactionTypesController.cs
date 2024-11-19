using BacklEndProyecto.Models;
using BacklEndProyecto.Services;
using Microsoft.AspNetCore.Mvc;

namespace BacklEndProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionTypesController : ControllerBase
    {
        private readonly ITransactionTypesService _transactionTypesService;

        public TransactionTypesController(ITransactionTypesService transactionTypesService)
        {
            _transactionTypesService = transactionTypesService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TransactionTypes>>> GetAllTransactionTypes()
        {
            var transactionTypes = await _transactionTypesService.GetAllTransactionTypesAsync();
            return Ok(transactionTypes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TransactionTypes>> GetTransactionTypeById(int id)
        {
            var transactionType = await _transactionTypesService.GetTransactionTypeByIdAsync(id);
            if (transactionType == null)
            {
                return NotFound();
            }
            return Ok(transactionType);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateTransactionType([FromBody] TransactionTypes transactionType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _transactionTypesService.CreateTransactionTypeAsync(transactionType);
            return CreatedAtAction(nameof(GetTransactionTypeById), new { id = transactionType.TransactionTypeId }, transactionType);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateTransactionType(int id, [FromBody] TransactionTypes transactionType)
        {
            var existingTransactionType = await _transactionTypesService.GetTransactionTypeByIdAsync(id);
            if (existingTransactionType == null)
            {
                return NotFound();
            }

            existingTransactionType.TransactionTypeNames = transactionType.TransactionTypeNames;
            existingTransactionType.Description = transactionType.Description;
            existingTransactionType.IsDeleted = transactionType.IsDeleted;

            await _transactionTypesService.UpdateTransactionTypeAsync(existingTransactionType);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTransactionType(int id)
        {
            var transactionType = await _transactionTypesService.GetTransactionTypeByIdAsync(id);
            if (transactionType == null)
            {
                return NotFound();
            }

            await _transactionTypesService.DeleteTransactionTypeAsync(id);
            return NoContent();
        }
    }

}
