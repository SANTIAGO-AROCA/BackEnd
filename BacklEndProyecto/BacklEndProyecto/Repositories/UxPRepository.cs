using BacklEndProyecto.Context;
using BacklEndProyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace BacklEndProyecto.Repositories
{
    public interface IUxPRepository
    {
        Task<IEnumerable<UserXPermission>> GetAllUxPAsync();
        Task CreateUxPAsync(UserXPermission userXPermission);
    }
    public class UxPRepository : IUxPRepository
    {
        private readonly BackEndDbContext dbContext;
        public UxPRepository(BackEndDbContext backEndDbContext)
        {
            dbContext = backEndDbContext;
        }

        public async Task CreateUxPAsync(UserXPermission userXPermission)
        {
            dbContext.UserXper.Add(userXPermission);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserXPermission>> GetAllUxPAsync()
        {
            return await dbContext.UserXper.Where(s => !s.IsDeleted).ToListAsync();
        }

    }
}
