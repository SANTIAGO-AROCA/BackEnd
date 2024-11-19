using BacklEndProyecto.Models;
using BacklEndProyecto.Repositories;

namespace BacklEndProyecto.Services
{
    public interface IUxPService
    {
        Task<IEnumerable<UserXPermission>> GetAllUxPAsync();
        Task CreateUxPAsync(UserXPermission userXPermission);
    }
    public class UxPService : IUxPService
    {
        private readonly IUxPRepository uxPRepository;
        public UxPService(IUxPRepository uxP)
        {
            uxPRepository = uxP;
        }

        public Task CreateUxPAsync(UserXPermission userXPermission)
        {
            return uxPRepository.CreateUxPAsync(userXPermission);
        }

        public Task<IEnumerable<UserXPermission>> GetAllUxPAsync()
        {
            return uxPRepository.GetAllUxPAsync();
        }
    }
}
