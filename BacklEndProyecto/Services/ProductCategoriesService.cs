using BacklEndProyecto.Models;
using BacklEndProyecto.Repositories;

namespace BacklEndProyecto.Services
{
    public interface IProductCategoriesService
    {
        Task<IEnumerable<ProductCategories>> GetAllProductCategoriesAsync();
        Task<ProductCategories> GetProductCategoryByIdAsync(int id);
        Task CreateProductCategoryAsync(ProductCategories productCategory);
        Task DeleteProductCategoryAsync(int id);
        Task UpdateProductCategoryAsync(ProductCategories productCategory);
    }

    public class ProductCategoriesService : IProductCategoriesService
    {
        private readonly IProductCategoriesRepository _productCategoriesRepository;

        public ProductCategoriesService(IProductCategoriesRepository repository)
        {
            _productCategoriesRepository = repository;
        }

        public Task CreateProductCategoryAsync(ProductCategories productCategory)
        {
            return _productCategoriesRepository.CreateProductCategoryAsync(productCategory);
        }

        public Task DeleteProductCategoryAsync(int id)
        {
            return _productCategoriesRepository.DeleteProductCategoryAsync(id);
        }

        public Task<IEnumerable<ProductCategories>> GetAllProductCategoriesAsync()
        {
            return _productCategoriesRepository.GetAllProductCategoriesAsync();
        }

        public Task<ProductCategories> GetProductCategoryByIdAsync(int id)
        {
            return _productCategoriesRepository.GetProductCategoryByIdAsync(id);
        }

        public Task UpdateProductCategoryAsync(ProductCategories productCategory)
        {
            return _productCategoriesRepository.UpdateProductCategoryAsync(productCategory);
        }
    }

}
