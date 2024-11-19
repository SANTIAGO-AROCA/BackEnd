using BacklEndProyecto.Models;
using BacklEndProyecto.Repositories;

namespace BacklEndProyecto.Services
{
    public interface IOrdersService
    {
        Task<IEnumerable<Orders>> GetAllOrdersAsync();
        Task<Orders> GetOrdersByIdAsync(int id);
        Task CreateOrdersAsync(Orders orders);
        Task DeleteOrdersAsync(int id);
        Task UpdateOrdersAsync(Orders orders);
    }

    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;

        public OrdersService(IOrdersRepository repository)
        {
            _ordersRepository = repository;
        }

        public Task CreateOrdersAsync(Orders orders)
        {
            return _ordersRepository.CreateOrdersAsync(orders);
        }

        public Task DeleteOrdersAsync(int id)
        {
            return _ordersRepository.DeleteOrdersAsync(id);
        }

        public Task<IEnumerable<Orders>> GetAllOrdersAsync()
        {
            return _ordersRepository.GetAllOrdersAsync();
        }

        public Task<Orders> GetOrdersByIdAsync(int id)
        {
            return _ordersRepository.GetOrdersByIdAsync(id);
        }

        public Task UpdateOrdersAsync(Orders orders)
        {
            return _ordersRepository.UpdateOrdersAsync(orders);
        }
    }

}
