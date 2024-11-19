using BacklEndProyecto.Context;
using BacklEndProyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace BacklEndProyecto.Repositories
{
    public interface IProductCategoriesRepository
    {
        Task<IEnumerable<ProductCategories>> GetAllProductCategoriesAsync();
        Task<ProductCategories> GetProductCategoryByIdAsync(int id);
        Task CreateProductCategoryAsync(ProductCategories productCategory);
        Task DeleteProductCategoryAsync(int id);
        Task UpdateProductCategoryAsync(ProductCategories productCategory);
    }

    public class ProductCategoriesRepository : IProductCategoriesRepository
    {
        private readonly BackEndDbContext dbContext;

        public ProductCategoriesRepository(BackEndDbContext context)
        {
            dbContext = context;
        }

        public async Task CreateProductCategoryAsync(ProductCategories productCategory)
        {
            dbContext.ProductCategories.Add(productCategory);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteProductCategoryAsync(int id)
        {
            var productCategory = await dbContext.ProductCategories.FindAsync(id);
            if (productCategory != null)
            {
                productCategory.IsDeleted = true;
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProductCategories>> GetAllProductCategoriesAsync()
        {
            return await dbContext.ProductCategories.Where(pc => !pc.IsDeleted).ToListAsync();
        }

        public async Task<ProductCategories> GetProductCategoryByIdAsync(int id)
        {
            return await dbContext.ProductCategories.FirstOrDefaultAsync(pc => !pc.IsDeleted && pc.CategoryId == id);
        }

        public async Task UpdateProductCategoryAsync(ProductCategories productCategory)
        {
            dbContext.ProductCategories.Update(productCategory);
            await dbContext.SaveChangesAsync();
        }
    }

}
