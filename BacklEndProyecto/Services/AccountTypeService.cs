using BacklEndProyecto.Models;
using BacklEndProyecto.Repositories;

namespace BacklEndProyecto.Services
{
    public interface IAccountTypeService
    {
        Task<IEnumerable<AccountType>> GetAllAccountTypesAsync();
        Task<AccountType> GetAccountTypeByIdAsync(int id);
        Task CreateAccountTypeAsync(AccountType accountType);
        Task DeleteAccountTypeAsync(int id);
        Task UpdateAccountTypeAsync(AccountType accountType);
    }

    public class AccountTypeService : IAccountTypeService
    {
        private readonly IAccountTypeRepository _accountTypeRepository;

        public AccountTypeService(IAccountTypeRepository repository)
        {
            _accountTypeRepository = repository;
        }

        public Task CreateAccountTypeAsync(AccountType accountType)
        {
            return _accountTypeRepository.CreateAccountTypeAsync(accountType);
        }

        public Task DeleteAccountTypeAsync(int id)
        {
            return _accountTypeRepository.DeleteAccountTypeAsync(id);
        }

        public Task<IEnumerable<AccountType>> GetAllAccountTypesAsync()
        {
            return _accountTypeRepository.GetAllAccountTypesAsync();
        }

        public Task<AccountType> GetAccountTypeByIdAsync(int id)
        {
            return _accountTypeRepository.GetAccountTypeByIdAsync(id);
        }

        public Task UpdateAccountTypeAsync(AccountType accountType)
        {
            return _accountTypeRepository.UpdateAccountTypeAsync(accountType);
        }
    }

}
