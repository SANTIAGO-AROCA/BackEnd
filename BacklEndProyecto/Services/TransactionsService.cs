using BacklEndProyecto.Models;
using BacklEndProyecto.Repositories;

namespace BacklEndProyecto.Services
{
    public interface ITransactionsService
    {
        Task<IEnumerable<Transactions>> GetAllTransactionsAsync();
        Task<Transactions> GetTransactionByIdAsync(int id);
        Task CreateTransactionAsync(Transactions transaction);
        Task UpdateTransactionAsync(Transactions transaction);
        Task DeleteTransactionAsync(int id);
    }

    public class TransactionsService : ITransactionsService
    {
        private readonly ITransactionsRepository transactionsRepository;

        public TransactionsService(ITransactionsRepository transactionsRepository)
        {
            this.transactionsRepository = transactionsRepository;
        }

        public Task CreateTransactionAsync(Transactions transaction)
        {
            return transactionsRepository.CreateTransactionAsync(transaction);
        }

        public Task DeleteTransactionAsync(int id)
        {
            return transactionsRepository.DeleteTransactionAsync(id);
        }

        public Task<IEnumerable<Transactions>> GetAllTransactionsAsync()
        {
            return transactionsRepository.GetAllTransactionsAsync();
        }

        public Task<Transactions> GetTransactionByIdAsync(int id)
        {
            return transactionsRepository.GetTransactionByIdAsync(id);
        }

        public Task UpdateTransactionAsync(Transactions transaction)
        {
            return transactionsRepository.UpdateTransactionAsync(transaction);
        }
    }

}
