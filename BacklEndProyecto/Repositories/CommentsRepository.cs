using BacklEndProyecto.Context;
using BacklEndProyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace BacklEndProyecto.Repositories
{
    public interface ICommentsRepository
    {
        Task<IEnumerable<Comments>> GetAllCommentsAsync();
        Task<Comments> GetCommentByIdAsync(int id);
        Task CreateCommentAsync(Comments comment);
        Task DeleteCommentAsync(int id);
        Task UpdateCommentAsync(Comments comment);
    }

    public class CommentsRepository : ICommentsRepository
    {
        private readonly BackEndDbContext dbContext;

        public CommentsRepository(BackEndDbContext context)
        {
            dbContext = context;
        }

        public async Task CreateCommentAsync(Comments comment)
        {
            dbContext.Comments.Add(comment);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteCommentAsync(int id)
        {
            var comment = await dbContext.Comments.FindAsync(id);
            if (comment != null)
            {
                comment.IsDeleted = true;
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Comments>> GetAllCommentsAsync()
        {
            return await dbContext.Comments.Where(c => !c.IsDeleted).ToListAsync();
        }

        public async Task<Comments> GetCommentByIdAsync(int id)
        {
            return await dbContext.Comments.FirstOrDefaultAsync(c => !c.IsDeleted && c.CommentId == id);
        }

        public async Task UpdateCommentAsync(Comments comment)
        {
            dbContext.Comments.Update(comment);
            await dbContext.SaveChangesAsync();
        }
    }

}
