using BacklEndProyecto.Context;
using BacklEndProyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace BacklEndProyecto.Repositories
{
    public interface ITransactionTypesRepository
    {
        Task<IEnumerable<TransactionTypes>> GetAllTransactionTypesAsync();
        Task<TransactionTypes> GetTransactionTypeByIdAsync(int id);
        Task CreateTransactionTypeAsync(TransactionTypes transactionType);
        Task UpdateTransactionTypeAsync(TransactionTypes transactionType);
        Task DeleteTransactionTypeAsync(int id);
    }

    public class TransactionTypesRepository : ITransactionTypesRepository
    {
        private readonly BackEndDbContext dbContext;

        public TransactionTypesRepository(BackEndDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateTransactionTypeAsync(TransactionTypes transactionType)
        {
            dbContext.TransactionTypes.Add(transactionType);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteTransactionTypeAsync(int id)
        {
            var transactionType = await dbContext.TransactionTypes.FindAsync(id);
            if (transactionType != null)
            {
                transactionType.IsDeleted = true;
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TransactionTypes>> GetAllTransactionTypesAsync()
        {
            return await dbContext.TransactionTypes.Where(s => !s.IsDeleted).ToListAsync();
        }

        public async Task<TransactionTypes> GetTransactionTypeByIdAsync(int id)
        {
            return await dbContext.TransactionTypes.FirstOrDefaultAsync(s => !s.IsDeleted && s.TransactionTypeId == id);
        }

        public async Task UpdateTransactionTypeAsync(TransactionTypes transactionType)
        {
            dbContext.TransactionTypes.Update(transactionType);
            await dbContext.SaveChangesAsync();
        }
    }

}
