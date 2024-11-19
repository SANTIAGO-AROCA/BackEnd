using BacklEndProyecto.Models;
using BacklEndProyecto.Repositories;

namespace BacklEndProyecto.Services
{
    public interface IOrderDetailsService
    {
        Task<IEnumerable<OrderDetails>> GetAllOrderDetailsAsync();
        Task<OrderDetails> GetOrderDetailsByIdAsync(int id);
        Task CreateOrderDetailsAsync(OrderDetails orderDetails);
        Task DeleteOrderDetailsAsync(int id);
        Task UpdateOrderDetailsAsync(OrderDetails orderDetails);
    }

    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly IOrderDetailsRepository _orderDetailsRepository;

        public OrderDetailsService(IOrderDetailsRepository repository)
        {
            _orderDetailsRepository = repository;
        }

        public Task CreateOrderDetailsAsync(OrderDetails orderDetails)
        {
            return _orderDetailsRepository.CreateOrderDetailsAsync(orderDetails);
        }

        public Task DeleteOrderDetailsAsync(int id)
        {
            return _orderDetailsRepository.DeleteOrderDetailsAsync(id);
        }

        public Task<IEnumerable<OrderDetails>> GetAllOrderDetailsAsync()
        {
            return _orderDetailsRepository.GetAllOrderDetailsAsync();
        }

        public Task<OrderDetails> GetOrderDetailsByIdAsync(int id)
        {
            return _orderDetailsRepository.GetOrderDetailsByIdAsync(id);
        }

        public Task UpdateOrderDetailsAsync(OrderDetails orderDetails)
        {
            return _orderDetailsRepository.UpdateOrderDetailsAsync(orderDetails);
        }
    }
}
