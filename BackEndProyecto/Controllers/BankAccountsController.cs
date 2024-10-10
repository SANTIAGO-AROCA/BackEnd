using BackEndProyecto.Context;
using BackEndProyecto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace BackEndProyecto.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BankAccountsController : ControllerBase
{
    private readonly dbcontextBank _context;

    public BankAccountsController(dbcontextBank context)
    {
        _context = context;
    }

    // GET: api/BankAccounts
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BankAccounts>>> GetBankAccounts()
    {
        // Obtener todas las cuentas bancarias que no están eliminadas
        return await _context.BankAccounts
                             .Where(b => !b.IsDeleted)
                             .ToListAsync();
    }

    // GET: api/BankAccounts/5
    [HttpGet("{id}")]
    public async Task<ActionResult<BankAccounts>> GetBankAccount(int id)
    {
        var bankAccount = await _context.BankAccounts.FindAsync(id);

        if (bankAccount == null || bankAccount.IsDeleted)
        {
            return NotFound();
        }

        return bankAccount;
    }

    // POST: api/BankAccounts
    [HttpPost]
    public async Task<ActionResult<BankAccounts>> PostBankAccount(BankAccounts bankAccount)
    {
        _context.BankAccounts.Add(bankAccount);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetBankAccount), new { id = bankAccount.AcountId }, bankAccount);
    }

    // PUT: api/BankAccounts/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutBankAccount(int id, BankAccounts bankAccount)
    {
        if (id != bankAccount.AcountId)
        {
            return BadRequest();
        }

        _context.Entry(bankAccount).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BankAccountExists(id))
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

    // DELETE: api/BankAccounts/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBankAccount(int id)
    {
        var bankAccount = await _context.BankAccounts.FindAsync(id);

        if (bankAccount == null || bankAccount.IsDeleted)
        {
            return NotFound();
        }

        // Marcar el IsDeleted como true en lugar de eliminarlo
        bankAccount.IsDeleted = true;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool BankAccountExists(int id)
    {
        return _context.BankAccounts.Any(b => b.AcountId == id && !b.IsDeleted);
    }
}



