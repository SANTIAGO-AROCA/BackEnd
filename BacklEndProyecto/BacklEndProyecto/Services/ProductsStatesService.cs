using BacklEndProyecto.Models;
using BacklEndProyecto.Repositories;

namespace BacklEndProyecto.Services
{
    public interface IProductsStatesService
    {
        Task<IEnumerable<ProductsStates>> GetAllProductsStatesAsync();
        Task<ProductsStates> GetProductsStateByIdAsync(int id);
        Task CreateProductsStateAsync(ProductsStates productsState);
        Task DeleteProductsStateAsync(int id);
        Task UpdateProductsStateAsync(ProductsStates productsState);
    }

    public class ProductsStatesService : IProductsStatesService
    {
        private readonly IProductsStatesRepository productsStatesRepository;

        public ProductsStatesService(IProductsStatesRepository productsStatesRepository)
        {
            this.productsStatesRepository = productsStatesRepository;
        }

        public Task CreateProductsStateAsync(ProductsStates productsState)
        {
            return productsStatesRepository.CreateProductsStateAsync(productsState);
        }

        public Task DeleteProductsStateAsync(int id)
        {
            return productsStatesRepository.DeleteProductsStateAsync(id);
        }

        public Task<IEnumerable<ProductsStates>> GetAllProductsStatesAsync()
        {
            return productsStatesRepository.GetAllProductsStatesAsync();
        }

        public Task<ProductsStates> GetProductsStateByIdAsync(int id)
        {
            return productsStatesRepository.GetProductsStateByIdAsync(id);
        }

        public Task UpdateProductsStateAsync(ProductsStates productsState)
        {
            return productsStatesRepository.UpdateProductsStateAsync(productsState);
        }
    }

}
