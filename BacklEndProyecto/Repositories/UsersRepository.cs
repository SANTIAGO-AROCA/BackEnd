using BacklEndProyecto.Context;
using BacklEndProyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace BacklEndProyecto.Repositories
{
    public interface IUsersRepository
    {
        Task<IEnumerable<Users>> GetAllUsersAsync();
        Task<Users> GetUsersByIdAsync(int id);
        Task CreateUserAsync(Users users);
        Task DeleteUserAsync(int id);
        Task UpdateUserAsync(Users users);
        Task<Users> LoginAsync(string user, string pass);
    }
    public class UsersRepository : IUsersRepository
    {
        private readonly BackEndDbContext dbContext;
        public UsersRepository(BackEndDbContext back)
        {
            dbContext = back;
        }

        public async Task CreateUserAsync(Users users)
        {
            dbContext.Users.Add(users);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await dbContext.Users.FindAsync(id);
            if (user != null)
            {
                user.IsDeleted = true;
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Users>> GetAllUsersAsync()
        {
            return await dbContext.Users.Where(u => !u.IsDeleted).ToListAsync();
        }

        public async Task<Users> GetUsersByIdAsync(int id)
        {
            return await dbContext.Users.FirstOrDefaultAsync(s => !s.IsDeleted && s.UserId == id);
        }

        public async Task<Users> LoginAsync(string user, string pass)
        { 
            return await dbContext.Users.
                Where(s => user == s.Email && pass == s.Passcode)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateUserAsync(Users users)
        {
            dbContext.Users.Update(users);
            await dbContext.SaveChangesAsync();
        }
    }
}
