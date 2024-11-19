using BacklEndProyecto.Models;
using BacklEndProyecto.Repositories;

namespace BacklEndProyecto.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<Products>> GetAllProductsAsync();
        Task<Products> GetProductByIdAsync(int id);
        Task CreateProductAsync(Products product);
        Task DeleteProductAsync(int id);
        Task UpdateProductAsync(Products product);
    }

    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public Task CreateProductAsync(Products product)
        {
            return productsRepository.CreateProductAsync(product);
        }

        public Task DeleteProductAsync(int id)
        {
            return productsRepository.DeleteProductAsync(id);
        }

        public Task<IEnumerable<Products>> GetAllProductsAsync()
        {
            return productsRepository.GetAllProductsAsync();
        }

        public Task<Products> GetProductByIdAsync(int id)
        {
            return productsRepository.GetProductByIdAsync(id);
        }

        public Task UpdateProductAsync(Products product)
        {
            return productsRepository.UpdateProductAsync(product);
        }
    }

}
