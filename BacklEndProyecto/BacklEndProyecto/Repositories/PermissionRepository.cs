using BacklEndProyecto.Context;
using BacklEndProyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace BacklEndProyecto.Repositories
{
    public interface IPermissionsRepository
    {
        Task<IEnumerable<Permissions>> GetAllPermissionsAsync();
        Task<Permissions> GetPermissionByIdAsync(int id);
        Task CreatePermissionAsync(Permissions permission);
        Task DeletePermissionAsync(int id);
        Task UpdatePermissionAsync(Permissions permission);
    }

    public class PermissionsRepository : IPermissionsRepository
    {
        private readonly BackEndDbContext dbContext;
        public PermissionsRepository(BackEndDbContext context)
        {
            dbContext = context;
        }

        public async Task CreatePermissionAsync(Permissions permission)
        {
            dbContext.Permissions.Add(permission);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeletePermissionAsync(int id)
        {
            var permission = await dbContext.Permissions.FindAsync(id);
            if (permission != null)
            {
                permission.IsDeleted = true;
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Permissions>> GetAllPermissionsAsync()
        {
            return await dbContext.Permissions.Where(p => !p.IsDeleted).ToListAsync();
        }

        public async Task<Permissions> GetPermissionByIdAsync(int id)
        {
            return await dbContext.Permissions
                .FirstOrDefaultAsync(p => !p.IsDeleted && p.PermissionId == id);
        }

        public async Task UpdatePermissionAsync(Permissions permission)
        {
            dbContext.Permissions.Update(permission);
            await dbContext.SaveChangesAsync();
        }
    }

}
