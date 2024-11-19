using BacklEndProyecto.Context;
using BacklEndProyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace BacklEndProyecto.Repositories
{
    public interface ITransactionsRepository
    {
        Task<IEnumerable<Transactions>> GetAllTransactionsAsync();
        Task<Transactions> GetTransactionByIdAsync(int id);
        Task CreateTransactionAsync(Transactions transaction);
        Task UpdateTransactionAsync(Transactions transaction);
        Task DeleteTransactionAsync(int id);
    }

    public class TransactionsRepository : ITransactionsRepository
    {
        private readonly BackEndDbContext dbContext;

        public TransactionsRepository(BackEndDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateTransactionAsync(Transactions transaction)
        {
            dbContext.Transactions.Add(transaction);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteTransactionAsync(int id)
        {
            var transaction = await dbContext.Transactions.FindAsync(id);
            if (transaction != null)
            {
                transaction.IsDeleted = true;
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Transactions>> GetAllTransactionsAsync()
        {
            return await dbContext.Transactions.Where(t => !t.IsDeleted).ToListAsync();
        }

        public async Task<Transactions> GetTransactionByIdAsync(int id)
        {
            return await dbContext.Transactions.FirstOrDefaultAsync(t => t.TransactionId == id && !t.IsDeleted);
        }

        public async Task UpdateTransactionAsync(Transactions transaction)
        {
            dbContext.Transactions.Update(transaction);
            await dbContext.SaveChangesAsync();
        }
    }

}
