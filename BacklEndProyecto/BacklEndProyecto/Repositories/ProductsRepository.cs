using BacklEndProyecto.Context;
using BacklEndProyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace BacklEndProyecto.Repositories
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Products>> GetAllProductsAsync();
        Task<Products> GetProductByIdAsync(int id);
        Task CreateProductAsync(Products product);
        Task DeleteProductAsync(int id);
        Task UpdateProductAsync(Products product);
    }

    public class ProductsRepository : IProductsRepository
    {
        private readonly BackEndDbContext dbContext;

        public ProductsRepository(BackEndDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateProductAsync(Products product)
        {
            dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await dbContext.Products.FindAsync(id);
            if (product != null)
            {
                product.IsDeleted = true;
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Products>> GetAllProductsAsync()
        {
            return await dbContext.Products.Where(p => !p.IsDeleted).ToListAsync();
        }

        public async Task<Products> GetProductByIdAsync(int id)
        {
            return await dbContext.Products.FirstOrDefaultAsync(p => !p.IsDeleted && p.ProductId == id);
        }

        public async Task UpdateProductAsync(Products product)
        {
            dbContext.Products.Update(product);
            await dbContext.SaveChangesAsync();
        }
    }

}
