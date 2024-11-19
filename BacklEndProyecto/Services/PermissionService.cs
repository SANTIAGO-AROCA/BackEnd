using BacklEndProyecto.Models;
using BacklEndProyecto.Repositories;

namespace BacklEndProyecto.Services
{
    public interface IPermissionService
    {
        Task<IEnumerable<Permissions>> GetAllPermissionsAsync();
        Task<Permissions> GetPermissionByIdAsync(int id);
        Task CreatePermissionAsync(Permissions permission);
        Task DeletePermissionAsync(int id);
        Task UpdatePermissionAsync(Permissions permission);
    }

    public class PermissionService : IPermissionService
    {
        private readonly IPermissionsRepository _permissionRepository;

        public PermissionService(IPermissionsRepository repository)
        {
            _permissionRepository = repository;
        }

        public Task CreatePermissionAsync(Permissions permission)
        {
            return _permissionRepository.CreatePermissionAsync(permission);
        }

        public Task DeletePermissionAsync(int id)
        {
            return _permissionRepository.DeletePermissionAsync(id);
        }

        public Task<IEnumerable<Permissions>> GetAllPermissionsAsync()
        {
            return _permissionRepository.GetAllPermissionsAsync();
        }

        public Task<Permissions> GetPermissionByIdAsync(int id)
        {
            return _permissionRepository.GetPermissionByIdAsync(id);
        }

        public Task UpdatePermissionAsync(Permissions permission)
        {
            return _permissionRepository.UpdatePermissionAsync(permission);
        }
    }

}
