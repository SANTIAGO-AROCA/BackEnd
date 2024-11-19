using BacklEndProyecto.Models;
using BacklEndProyecto.Repositories;

namespace BacklEndProyecto.Services
{
    public interface ITransactionTypesService
    {
        Task<IEnumerable<TransactionTypes>> GetAllTransactionTypesAsync();
        Task<TransactionTypes> GetTransactionTypeByIdAsync(int id);
        Task CreateTransactionTypeAsync(TransactionTypes transactionType);
        Task UpdateTransactionTypeAsync(TransactionTypes transactionType);
        Task DeleteTransactionTypeAsync(int id);
    }

    public class TransactionTypesService : ITransactionTypesService
    {
        private readonly ITransactionTypesRepository transactionTypesRepository;

        public TransactionTypesService(ITransactionTypesRepository transactionTypesRepository)
        {
            this.transactionTypesRepository = transactionTypesRepository;
        }

        public Task CreateTransactionTypeAsync(TransactionTypes transactionType)
        {
            return transactionTypesRepository.CreateTransactionTypeAsync(transactionType);
        }

        public Task DeleteTransactionTypeAsync(int id)
        {
            return transactionTypesRepository.DeleteTransactionTypeAsync(id);
        }

        public Task<IEnumerable<TransactionTypes>> GetAllTransactionTypesAsync()
        {
            return transactionTypesRepository.GetAllTransactionTypesAsync();
        }

        public Task<TransactionTypes> GetTransactionTypeByIdAsync(int id)
        {
            return transactionTypesRepository.GetTransactionTypeByIdAsync(id);
        }

        public Task UpdateTransactionTypeAsync(TransactionTypes transactionType)
        {
            return transactionTypesRepository.UpdateTransactionTypeAsync(transactionType);
        }
    }

}
