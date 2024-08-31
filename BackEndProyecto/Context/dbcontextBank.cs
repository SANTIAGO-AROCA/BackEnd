using BackEndProyecto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BackEndProyecto.Context
{
    public class dbcontextBank : DbContext
    {
        public dbcontextBank(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<Users> users { get; set; }

// OnModelCreating Tarea
    }
}
