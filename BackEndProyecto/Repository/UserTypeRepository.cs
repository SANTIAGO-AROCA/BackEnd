using BackEndProyecto.Context;
using BackEndProyecto.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using static BackEndProyecto.Models.prueba;

namespace BackEndProyecto.Repository
{
    public interface IUserTypeRepository
    {
        Task<IEnumerable<UserStates >> GetAllSubjectsAsunc();
        Task<UserStates> GetSubjectByIdAsync(int id);
        Task CreateSubjectAsync(UserStates subject);
        Task UpdateSubjectAsync(UserStates subject);
        Task softDeleteSubjectAsync(int id);
    }
    public class UserTypeRepository : IUserTypeRepository
    {
        private readonly dbcontextBank _context;

        public UserTypeRepository(dbcontextBank context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserStates>> GetAllSubjectsAsync()
        {
            return await _context.UserStates
                .Where(s => !s.IsDeleted)
                .ToListAsync();
        }
        public async Task<UserStates> GetSubjectByIdAsync(int id)
        {
            return await _context.UserStates
                .FirstOrDefaultAsync(s => s.Id = id && !s.IsDeleted);
        }
        public async Task SoftDeletedSubjectAsync(int id)
        {
            var UserStates = await _context.UserStates.FindAsync(id);
            if (UserStates != null)
            {
                UserStates.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
