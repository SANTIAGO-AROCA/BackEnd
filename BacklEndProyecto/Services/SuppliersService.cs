using BacklEndProyecto.Models;
using BacklEndProyecto.Repositories;

namespace BacklEndProyecto.Services
{
    public interface ISuppliersService
    {
        Task<IEnumerable<Suppliers>> GetAllSuppliersAsync();
        Task<Suppliers> GetSupplierByIdAsync(int id);
        Task CreateSupplierAsync(Suppliers supplier);
        Task DeleteSupplierAsync(int id);
        Task UpdateSupplierAsync(Suppliers supplier);
    }

    public class SuppliersService : ISuppliersService
    {
        private readonly ISuppliersRepository suppliersRepository;

        public SuppliersService(ISuppliersRepository suppliersRepository)
        {
            this.suppliersRepository = suppliersRepository;
        }

        public Task CreateSupplierAsync(Suppliers supplier)
        {
            return suppliersRepository.CreateSupplierAsync(supplier);
        }

        public Task DeleteSupplierAsync(int id)
        {
            return suppliersRepository.DeleteSupplierAsync(id);
        }

        public Task<IEnumerable<Suppliers>> GetAllSuppliersAsync()
        {
            return suppliersRepository.GetAllSuppliersAsync();
        }

        public Task<Suppliers> GetSupplierByIdAsync(int id)
        {
            return suppliersRepository.GetSupplierByIdAsync(id);
        }

        public Task UpdateSupplierAsync(Suppliers supplier)
        {
            return suppliersRepository.UpdateSupplierAsync(supplier);
        }
    }

}
