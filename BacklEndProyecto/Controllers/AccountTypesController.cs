using BacklEndProyecto.Models;
using BacklEndProyecto.Services;
using Microsoft.AspNetCore.Mvc;

namespace BacklEndProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTypesController : ControllerBase
    {
        private readonly IAccountTypeService _accountTypeService;

        public AccountTypesController(IAccountTypeService accountTypeService)
        {
            _accountTypeService = accountTypeService;
        }

        // GET: api/AccountTypes
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AccountType>>> GetAllAccountTypes()
        {
            var accountTypes = await _accountTypeService.GetAllAccountTypesAsync();
            return Ok(accountTypes);
        }

        // GET: api/AccountTypes/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AccountType>> GetAccountTypeById(int id)
        {
            var accountType = await _accountTypeService.GetAccountTypeByIdAsync(id);
            if (accountType == null)
            {
                return NotFound();
            }
            return Ok(accountType);
        }

        // POST: api/AccountTypes
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateAccountType([FromForm] AccountType accountType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _accountTypeService.CreateAccountTypeAsync(accountType);
            return CreatedAtAction(nameof(GetAccountTypeById), new { id = accountType.AccountTypeId }, accountType);
        }

        // PUT: api/AccountTypes/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAccountType(int id, [FromForm] string accountTypeName, string accountTypeDescription, bool isDeleted)
        {
            var existingAccountType = await _accountTypeService.GetAccountTypeByIdAsync(id);
            if (existingAccountType == null)
            {
                return NotFound();
            }

            existingAccountType.AccounTypetName = accountTypeName;
            existingAccountType.AccountTypeDescription = accountTypeDescription;
            existingAccountType.IsDeleted = isDeleted;

            await _accountTypeService.UpdateAccountTypeAsync(existingAccountType);
            return NoContent();
        }

        // DELETE: api/AccountTypes/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteAccountType(int id)
        {
            var accountType = await _accountTypeService.GetAccountTypeByIdAsync(id);
            if (accountType == null)
            {
                return NotFound();
            }

            await _accountTypeService.DeleteAccountTypeAsync(id);
            return NoContent();
        }
    }

}
