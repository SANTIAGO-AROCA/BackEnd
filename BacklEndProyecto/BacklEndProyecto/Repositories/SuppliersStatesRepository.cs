using BacklEndProyecto.Context;
using BacklEndProyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace BacklEndProyecto.Repositories
{
    public interface ISuppliersStatesRepository
    {
        Task<IEnumerable<SuppliersStates>> GetAllSuppliersStatesAsync();
        Task<SuppliersStates> GetSuppliersStateByIdAsync(int id);
        Task CreateSuppliersStateAsync(SuppliersStates suppliersState);
        Task UpdateSuppliersStateAsync(SuppliersStates suppliersState);
        Task DeleteSuppliersStateAsync(int id);
    }

    public class SuppliersStatesRepository : ISuppliersStatesRepository
    {
        private readonly BackEndDbContext dbContext;

        public SuppliersStatesRepository(BackEndDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateSuppliersStateAsync(SuppliersStates suppliersState)
        {
            dbContext.SuppliersStates.Add(suppliersState);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteSuppliersStateAsync(int id)
        {
            var suppliersState = await dbContext.SuppliersStates.FindAsync(id);
            if (suppliersState != null)
            {
                suppliersState.IsDeleted = true;
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<SuppliersStates>> GetAllSuppliersStatesAsync()
        {
            return await dbContext.SuppliersStates.Where(s => !s.IsDeleted).ToListAsync();
        }

        public async Task<SuppliersStates> GetSuppliersStateByIdAsync(int id)
        {
            return await dbContext.SuppliersStates.FirstOrDefaultAsync(s => !s.IsDeleted && s.SupplierStateId == id);
        }

        public async Task UpdateSuppliersStateAsync(SuppliersStates suppliersState)
        {
            dbContext.SuppliersStates.Update(suppliersState);
            await dbContext.SaveChangesAsync();
        }
    }

}
