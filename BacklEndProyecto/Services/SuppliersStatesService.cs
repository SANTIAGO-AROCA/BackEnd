using BacklEndProyecto.Models;
using BacklEndProyecto.Repositories;

namespace BacklEndProyecto.Services
{
    public interface ISuppliersStatesService
    {
        Task<IEnumerable<SuppliersStates>> GetAllSuppliersStatesAsync();
        Task<SuppliersStates> GetSuppliersStateByIdAsync(int id);
        Task CreateSuppliersStateAsync(SuppliersStates suppliersState);
        Task UpdateSuppliersStateAsync(SuppliersStates suppliersState);
        Task DeleteSuppliersStateAsync(int id);
    }

    public class SuppliersStatesService : ISuppliersStatesService
    {
        private readonly ISuppliersStatesRepository suppliersStatesRepository;

        public SuppliersStatesService(ISuppliersStatesRepository suppliersStatesRepository)
        {
            this.suppliersStatesRepository = suppliersStatesRepository;
        }

        public Task CreateSuppliersStateAsync(SuppliersStates suppliersState)
        {
            return suppliersStatesRepository.CreateSuppliersStateAsync(suppliersState);
        }

        public Task DeleteSuppliersStateAsync(int id)
        {
            return suppliersStatesRepository.DeleteSuppliersStateAsync(id);
        }

        public Task<IEnumerable<SuppliersStates>> GetAllSuppliersStatesAsync()
        {
            return suppliersStatesRepository.GetAllSuppliersStatesAsync();
        }

        public Task<SuppliersStates> GetSuppliersStateByIdAsync(int id)
        {
            return suppliersStatesRepository.GetSuppliersStateByIdAsync(id);
        }

        public Task UpdateSuppliersStateAsync(SuppliersStates suppliersState)
        {
            return suppliersStatesRepository.UpdateSuppliersStateAsync(suppliersState);
        }
    }

}
