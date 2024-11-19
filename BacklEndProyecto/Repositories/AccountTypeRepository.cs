using BacklEndProyecto.Context;
using BacklEndProyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace BacklEndProyecto.Repositories
{
    public interface IAccountTypeRepository
    {
        Task<IEnumerable<AccountType>> GetAllAccountTypesAsync();
        Task<AccountType> GetAccountTypeByIdAsync(int id);
        Task CreateAccountTypeAsync(AccountType accountType);
        Task DeleteAccountTypeAsync(int id);
        Task UpdateAccountTypeAsync(AccountType accountType);
    }

    public class AccountTypeRepository : IAccountTypeRepository
    {
        private readonly BackEndDbContext dbContext;

        public AccountTypeRepository(BackEndDbContext context)
        {
            dbContext = context;
        }

        public async Task CreateAccountTypeAsync(AccountType accountType)
        {
            dbContext.AccountTypes.Add(accountType);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAccountTypeAsync(int id)
        {
            var accountType = await dbContext.AccountTypes.FindAsync(id);
            if (accountType != null)
            {
                accountType.IsDeleted = true;
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<AccountType>> GetAllAccountTypesAsync()
        {
            return await dbContext.AccountTypes.Where(at => !at.IsDeleted).ToListAsync();
        }

        public async Task<AccountType> GetAccountTypeByIdAsync(int id)
        {
            return await dbContext.AccountTypes.FirstOrDefaultAsync(at => !at.IsDeleted && at.AccountTypeId == id);
        }

        public async Task UpdateAccountTypeAsync(AccountType accountType)
        {
            dbContext.AccountTypes.Update(accountType);
            await dbContext.SaveChangesAsync();
        }
    }

}
