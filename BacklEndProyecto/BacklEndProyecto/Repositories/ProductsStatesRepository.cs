using BacklEndProyecto.Context;
using BacklEndProyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace BacklEndProyecto.Repositories
{
    public interface IProductsStatesRepository
    {
        Task<IEnumerable<ProductsStates>> GetAllProductsStatesAsync();
        Task<ProductsStates> GetProductsStateByIdAsync(int id);
        Task CreateProductsStateAsync(ProductsStates productsState);
        Task DeleteProductsStateAsync(int id);
        Task UpdateProductsStateAsync(ProductsStates productsState);
    }

    public class ProductsStatesRepository : IProductsStatesRepository
    {
        private readonly BackEndDbContext dbContext;

        public ProductsStatesRepository(BackEndDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateProductsStateAsync(ProductsStates productsState)
        {
            dbContext.ProductsStates.Add(productsState);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteProductsStateAsync(int id)
        {
            var productsState = await dbContext.ProductsStates.FindAsync(id);
            if (productsState != null)
            {
                productsState.IsDeleted = true;
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProductsStates>> GetAllProductsStatesAsync()
        {
            return await dbContext.ProductsStates.Where(ps => !ps.IsDeleted).ToListAsync();
        }

        public async Task<ProductsStates> GetProductsStateByIdAsync(int id)
        {
            return await dbContext.ProductsStates.FirstOrDefaultAsync(ps => !ps.IsDeleted && ps.ProductStateId == id);
        }

        public async Task UpdateProductsStateAsync(ProductsStates productsState)
        {
            dbContext.ProductsStates.Update(productsState);
            await dbContext.SaveChangesAsync();
        }
    }


}
