using BacklEndProyecto.Models;
using BacklEndProyecto.Repositories;

namespace BacklEndProyecto.Services
{
    public interface IBankService
    {
        Task<IEnumerable<BankAccounts>> GetAllBankssAsync();
        Task<BankAccounts> GetBanksByIdAsync(int id);
        Task CreateBanksAsync(BankAccounts bankAccounts);
        Task DeleteBanksAsync(int id);
        Task UpdateBanksAsync(BankAccounts bankAccounts);
    }
    public class BankService : IBankService
    {
        private readonly IBankRepository bank;
        public BankService(IBankRepository bankRepository)
        {
            bank = bankRepository;
        }

        public Task CreateBanksAsync(BankAccounts bankAccounts)
        {
            return bank.CreateBanksAsync(bankAccounts);
        }

        public Task DeleteBanksAsync(int id)
        {
            return bank.DeleteBanksAsync(id);
        }

        public Task<IEnumerable<BankAccounts>> GetAllBankssAsync()
        {
            return bank.GetAllBankssAsync();
        }

        public Task<BankAccounts> GetBanksByIdAsync(int id)
        {
            return bank.GetBanksByIdAsync(id);
        }

        public Task UpdateBanksAsync(BankAccounts bankAccounts)
        {
            return bank.UpdateBanksAsync(bankAccounts);
        }
    }
}
