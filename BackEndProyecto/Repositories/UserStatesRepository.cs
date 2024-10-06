using BackEndProyecto.Context;
using BackEndProyecto.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace BackEndProyecto.Repository
{
    public interface IUserStatesRepository
    {
        Task<IEnumerable<UserStates>> GetAllUserStatesAsync();
        Task<UserStates> GetUserStatesByIdAsync(int userStateId);
        Task CreateUserStatesAsync(UserStates userStates);
        Task UpdateUserStatesAsync(UserStates userStates);
        Task SoftDeleteUserStatesAsync(int userStateId);
    }

    public class UserStateRepository : IUserStatesRepository
    {
        private readonly dbcontextBank _context;

        public UserStateRepository(dbcontextBank context)
        {
            _context = context;
        }

        public Task CreateUserStatesAsync(UserStates userStates)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserStates>> GetAllUserStatesAsync()
        {
            return await _context.UserStates
                .Where(s => !s.IsDeleted) //Incluir eliminados
                .ToListAsync();

        }

        public async Task<UserStates> GetUserStatesByIdAsync(int userStateId)
        {
            return await _context.UserStates
                .FirstOrDefaultAsync(s => s.UserStateId == userStateId && !s.IsDeleted);
        }

        public async Task SoftDeleteUserStateAsync(int userStateid)
        {
            var userStates = await _context.UserStates.FindAsync(userStateid);
            if (userStates != null)
            {
                userStates.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public Task SoftDeleteUserStatesAsync(int userStateId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserStatesAsync(UserStates userStates)
        {
            throw new NotImplementedException();
        }
    }
}