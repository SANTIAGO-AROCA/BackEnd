using BacklEndProyecto.Context;
using BacklEndProyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace BacklEndProyecto.Repositories
{
    public interface IOrderDetailsRepository
    {
        Task<IEnumerable<OrderDetails>> GetAllOrderDetailsAsync();
        Task<OrderDetails> GetOrderDetailsByIdAsync(int id);
        Task CreateOrderDetailsAsync(OrderDetails orderDetails);
        Task DeleteOrderDetailsAsync(int id);
        Task UpdateOrderDetailsAsync(OrderDetails orderDetails);
    }

    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private readonly BackEndDbContext dbContext;

        public OrderDetailsRepository(BackEndDbContext context)
        {
            dbContext = context;
        }

        public async Task CreateOrderDetailsAsync(OrderDetails orderDetails)
        {
            dbContext.OrderDetails.Add(orderDetails);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteOrderDetailsAsync(int id)
        {
            var orderDetails = await dbContext.OrderDetails.FindAsync(id);
            if (orderDetails != null)
            {
                orderDetails.IsDeleted = true;
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<OrderDetails>> GetAllOrderDetailsAsync()
        {
            return await dbContext.OrderDetails.Where(o => !o.IsDeleted).ToListAsync();
        }

        public async Task<OrderDetails> GetOrderDetailsByIdAsync(int id)
        {
            return await dbContext.OrderDetails.FirstOrDefaultAsync(o => !o.IsDeleted && o.OrderDetailsId == id);
        }

        public async Task UpdateOrderDetailsAsync(OrderDetails orderDetails)
        {
            dbContext.OrderDetails.Update(orderDetails);
            await dbContext.SaveChangesAsync();
        }
    }
}
