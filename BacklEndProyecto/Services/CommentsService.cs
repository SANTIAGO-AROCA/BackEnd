using BacklEndProyecto.Models;
using BacklEndProyecto.Repositories;

namespace BacklEndProyecto.Services
{
    public interface ICommentsService
    {
        Task<IEnumerable<Comments>> GetAllCommentsAsync();
        Task<Comments> GetCommentByIdAsync(int id);
        Task CreateCommentAsync(Comments comment);
        Task DeleteCommentAsync(int id);
        Task UpdateCommentAsync(Comments comment);
    }

    public class CommentsService : ICommentsService
    {
        private readonly ICommentsRepository _commentsRepository;

        public CommentsService(ICommentsRepository repository)
        {
            _commentsRepository = repository;
        }

        public Task CreateCommentAsync(Comments comment)
        {
            return _commentsRepository.CreateCommentAsync(comment);
        }

        public Task DeleteCommentAsync(int id)
        {
            return _commentsRepository.DeleteCommentAsync(id);
        }

        public Task<IEnumerable<Comments>> GetAllCommentsAsync()
        {
            return _commentsRepository.GetAllCommentsAsync();
        }

        public Task<Comments> GetCommentByIdAsync(int id)
        {
            return _commentsRepository.GetCommentByIdAsync(id);
        }

        public Task UpdateCommentAsync(Comments comment)
        {
            return _commentsRepository.UpdateCommentAsync(comment);
        }
    }

}
