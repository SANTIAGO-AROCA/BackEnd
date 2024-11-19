using BacklEndProyecto.Context;
using BacklEndProyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace BacklEndProyecto.Repositories
{
    public interface IUserStateRepository
    {
        Task<IEnumerable<UserStates>> GetAllUserStatesAsync();
        Task<UserStates> GetUserStateByIdAsync(int id);
        Task CreateUserStateAsync(UserStates userState);
        Task DeleteUserStateAsync(int id);
        Task UpdateUserStateAsync(UserStates userState);
    }

    public class UserStateRepository : IUserStateRepository
    {
        private readonly BackEndDbContext dbContext;
        public UserStateRepository(BackEndDbContext context)
        {
            dbContext = context;
        }

        public async Task CreateUserStateAsync(UserStates userState)
        {
            dbContext.UserStates.Add(userState);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteUserStateAsync(int id)
        {
            var userState = await dbContext.UserStates.FindAsync(id);
            if (userState != null)
            {
                userState.IsDeleted = true;
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<UserStates>> GetAllUserStatesAsync()
        {
            return await dbContext.UserStates.Where(us => !us.IsDeleted).ToListAsync();
        }

        public async Task<UserStates> GetUserStateByIdAsync(int id)
        {
            return await dbContext.UserStates.FirstOrDefaultAsync(us => !us.IsDeleted && us.UserStateId == id);
        }

        public async Task UpdateUserStateAsync(UserStates userState)
        {
            dbContext.UserStates.Update(userState);
            await dbContext.SaveChangesAsync();
        }
    }

}
