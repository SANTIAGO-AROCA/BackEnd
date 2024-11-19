using BacklEndProyecto.Context;
using BacklEndProyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace BacklEndProyecto.Repositories
{
    public interface ISuppliersRepository
    {
        Task<IEnumerable<Suppliers>> GetAllSuppliersAsync();
        Task<Suppliers> GetSupplierByIdAsync(int id);
        Task CreateSupplierAsync(Suppliers supplier);
        Task DeleteSupplierAsync(int id);
        Task UpdateSupplierAsync(Suppliers supplier);
    }

    public class SuppliersRepository : ISuppliersRepository
    {
        private readonly BackEndDbContext dbContext;

        public SuppliersRepository(BackEndDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateSupplierAsync(Suppliers supplier)
        {
            dbContext.Suppliers.Add(supplier);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteSupplierAsync(int id)
        {
            var supplier = await dbContext.Suppliers.FindAsync(id);
            if (supplier != null)
            {
                supplier.IsDeleted = true; 
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Suppliers>> GetAllSuppliersAsync()
        {
            return await dbContext.Suppliers.Where(s => !s.IsDeleted)
                .ToListAsync();
        }

        public async Task<Suppliers> GetSupplierByIdAsync(int id)
        {
            return await dbContext.Suppliers
                .FirstOrDefaultAsync(s => s.SupplierId == id && !s.IsDeleted);
        }

        public async Task UpdateSupplierAsync(Suppliers supplier)
        {
            dbContext.Suppliers.Update(supplier);
            await dbContext.SaveChangesAsync();
        }
    }

}
