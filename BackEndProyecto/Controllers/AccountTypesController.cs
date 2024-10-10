using BackEndProyecto.Context;
using BackEndProyecto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace BackEndProyecto.Controllers
{
    public class AccountTypesController: ControllerBase
    {
        private readonly dbcontextBank _context;

        public AccountTypesController(dbcontextBank context)
        {
            _context = context;
        }

        // GET: api/AccountTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountType>>> GetAccountTypes()
        {
            // Filtrar los AccountTypes que no estén marcados como eliminados
            return await _context.AccountTypes
                                 .Where(a => !a.IsDeleted)
                                 .ToListAsync();
        }

        // GET: api/AccountTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountType>> GetAccountType(int id)
        {
            var accountType = await _context.AccountTypes
                                            .Where(a => !a.IsDeleted)
                                            .FirstOrDefaultAsync(a => a.AccountTypeId == id);

            if (accountType == null)
            {
                return NotFound();
            }

            return accountType;
        }

        // POST: api/AccountTypes
        [HttpPost("{id}")]
        public async Task<ActionResult<AccountType>> PostAccountType(AccountType accountType)
        {
            _context.AccountTypes.Add(accountType);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAccountType), new { id = accountType.AccountTypeId }, accountType);
        }

        // PUT: api/AccountTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountType(int id, AccountType accountType)
        {
            if (id != accountType.AccountTypeId)
            {
                return BadRequest();
            }

            _context.Entry(accountType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountTypeExists(id))
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

        // DELETE: api/AccountTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccountType(int id)
        {
            var accountType = await _context.AccountTypes.FindAsync(id);

            if (accountType == null)
            {
                return NotFound();
            }

            // En lugar de eliminar, marca el IsDeleted como true
            accountType.IsDeleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Método auxiliar para verificar si el AccountType existe
        private bool AccountTypeExists(int id)
        {
            return _context.AccountTypes.Any(e => e.AccountTypeId == id && !e.IsDeleted);
        }
    }
}
