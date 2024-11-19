using BacklEndProyecto.Models;
using BacklEndProyecto.Services;
using Microsoft.AspNetCore.Mvc;

namespace BacklEndProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IBankService _bankService;

        public BankController(IBankService bankService)
        {
            _bankService = bankService;
        }

        // GET: api/Bank
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BankAccounts>>> GetAllBankAccounts()
        {
            var accounts = await _bankService.GetAllBankssAsync();
            return Ok(accounts);
        }

        // GET: api/Bank/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BankAccounts>> GetBankAccountById(int id)
        {
            var account = await _bankService.GetBanksByIdAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            return Ok(account);
        }

        // POST: api/Bank
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateBankAccount([FromForm] int userId, int accountNumber, int accountTypeId, float balance, int movements, DateTime creationDate, bool isDeleted)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BankAccounts account = new BankAccounts
            {
                UserId = userId,
                AcountNumber = accountNumber,
                AccountTypeId = accountTypeId,
                Balance = balance,
                Movements = movements,
                CreationDate = creationDate,
                IsDeleted = isDeleted,
                Users = null,
                AccountType = null
            };

            await _bankService.CreateBanksAsync(account);
            return CreatedAtAction(nameof(GetBankAccountById), new { id = account.AcountId }, account);
        }

        // PUT: api/Bank/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateBankAccount(int id, [FromForm] int userId, 
            int accountNumber, int accountTypeId, float balance, int movements,
            DateTime creationDate, bool isDeleted)
        {
            var existingAccount = await _bankService.GetBanksByIdAsync(id);
            if (existingAccount == null)
            {
                return NotFound();
            }

            existingAccount.UserId = userId;
            existingAccount.AcountNumber = accountNumber;
            existingAccount.AccountTypeId = accountTypeId;
            existingAccount.Balance = balance;
            existingAccount.Movements = movements;
            existingAccount.CreationDate = creationDate;
            existingAccount.IsDeleted = isDeleted;

            await _bankService.UpdateBanksAsync(existingAccount);
            return NoContent();
        }

        // DELETE: api/Bank/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteBankAccount(int id)
        {
            var account = await _bankService.GetBanksByIdAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            await _bankService.DeleteBanksAsync(id);
            return NoContent();
        }
    }

}
