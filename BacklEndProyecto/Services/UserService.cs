using BacklEndProyecto.Models;
using BacklEndProyecto.Repositories;

namespace BacklEndProyecto.Services
{
    public interface IUserService
    {
        Task<IEnumerable<Users>> GetAllUsersAsync();
        Task<Users> GetUsersByIdAsync(int id);
        Task CreateUserAsync(Users users);
        Task DeleteUserAsync(int id);
        Task UpdateUserAsync(Users users);
        Task<Users> LoginAsync(string user, string pass);
    }
    public class UserService : IUserService
    {
        private readonly IUsersRepository userRe;
        public UserService(IUsersRepository repository)
        {
            userRe = repository;
        }

        public Task CreateUserAsync(Users users)
        {
            return userRe.CreateUserAsync(users);   
        }

        public Task DeleteUserAsync(int id)
        {
            return userRe.DeleteUserAsync(id);
        }

        public Task<IEnumerable<Users>> GetAllUsersAsync()
        {
            return userRe.GetAllUsersAsync();
        }

        public Task<Users> GetUsersByIdAsync(int id)
        {
            return userRe.GetUsersByIdAsync(id);
        }

        public Task<Users> LoginAsync(string user, string pass)
        {
            return userRe.LoginAsync(user, pass);
        }

        public Task UpdateUserAsync(Users users)
        {
            return userRe.UpdateUserAsync(users);
        }
    }
}
