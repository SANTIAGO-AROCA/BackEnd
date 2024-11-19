using BacklEndProyecto.Models;
using BacklEndProyecto.Repositories;

namespace BacklEndProyecto.Services
{
    public interface IUserStateService
    {
        Task<IEnumerable<UserStates>> GetAllUserStatesAsync();
        Task<UserStates> GetUserStateByIdAsync(int id);
        Task CreateUserStateAsync(UserStates userState);
        Task DeleteUserStateAsync(int id);
        Task UpdateUserStateAsync(UserStates userState);
    }

    public class UserStateService : IUserStateService
    {
        private readonly IUserStateRepository _userStateRepository;

        public UserStateService(IUserStateRepository repository)
        {
            _userStateRepository = repository;
        }

        public Task CreateUserStateAsync(UserStates userState)
        {
            return _userStateRepository.CreateUserStateAsync(userState);
        }

        public Task DeleteUserStateAsync(int id)
        {
            return _userStateRepository.DeleteUserStateAsync(id);
        }

        public Task<IEnumerable<UserStates>> GetAllUserStatesAsync()
        {
            return _userStateRepository.GetAllUserStatesAsync();
        }

        public Task<UserStates> GetUserStateByIdAsync(int id)
        {
            return _userStateRepository.GetUserStateByIdAsync(id);
        }

        public Task UpdateUserStateAsync(UserStates userState)
        {
            return _userStateRepository.UpdateUserStateAsync(userState);
        }
    }

}
