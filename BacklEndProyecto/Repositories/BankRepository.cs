using BacklEndProyecto.Context;
using BacklEndProyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace BacklEndProyecto.Repositories
{
    public interface IBankRepository
    {
        Task<IEnumerable<BankAccounts>> GetAllBankssAsync();
        Task<BankAccounts> GetBanksByIdAsync(int id);
        Task CreateBanksAsync(BankAccounts bankAccounts);
        Task DeleteBanksAsync(int id);
        Task UpdateBanksAsync(BankAccounts bankAccounts);
    }
    public class BankRepository : IBankRepository
    {
        private readonly BackEndDbContext Context;
        public BankRepository(BackEndDbContext backEndDbContext)
        {
            Context = backEndDbContext;
        }

        public async Task CreateBanksAsync(BankAccounts bankAccounts)
        {
            Context.BankAccounts.Add(bankAccounts);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteBanksAsync(int id)
        {
            var bank = await Context.BankAccounts.FindAsync(id);
            if (bank != null)
            {
                bank.IsDeleted = true;
                await Context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<BankAccounts>> GetAllBankssAsync()
        {
            return await Context.BankAccounts.Where(s => !s.IsDeleted).ToListAsync();
        }

        public async Task<BankAccounts> GetBanksByIdAsync(int id)
        {
            return await Context.BankAccounts.
                FirstOrDefaultAsync(s => !s.IsDeleted && s.AcountId == id);
        }

        public async Task UpdateBanksAsync(BankAccounts bankAccounts)
        {
            Context.BankAccounts.Update(bankAccounts);
            await Context.SaveChangesAsync();
        }
    }
}
