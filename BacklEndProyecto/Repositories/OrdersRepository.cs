using BacklEndProyecto.Context;
using BacklEndProyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace BacklEndProyecto.Repositories
{
    public interface IOrdersRepository
    {
        Task<IEnumerable<Orders>> GetAllOrdersAsync();
        Task<Orders> GetOrdersByIdAsync(int id);
        Task CreateOrdersAsync(Orders orders);
        Task DeleteOrdersAsync(int id);
        Task UpdateOrdersAsync(Orders orders);
    }

    public class OrdersRepository : IOrdersRepository
    {
        private readonly BackEndDbContext dbContext;

        public OrdersRepository(BackEndDbContext context)
        {
            dbContext = context;
        }

        public async Task CreateOrdersAsync(Orders orders)
        {
            dbContext.Orders.Add(orders);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteOrdersAsync(int id)
        {
            var orders = await dbContext.Orders.FindAsync(id);
            if (orders != null)
            {
                orders.IsDeleted = true;
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Orders>> GetAllOrdersAsync()
        {
            return await dbContext.Orders.Where(o => !o.IsDeleted).ToListAsync();
        }

        public async Task<Orders> GetOrdersByIdAsync(int id)
        {
            return await dbContext.Orders.FirstOrDefaultAsync(o => !o.IsDeleted && o.OrderId == id);
        }

        public async Task UpdateOrdersAsync(Orders orders)
        {
            dbContext.Orders.Update(orders);
            await dbContext.SaveChangesAsync();
        }
    }

}
