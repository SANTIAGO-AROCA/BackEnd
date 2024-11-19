using BacklEndProyecto.Context;
using BacklEndProyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace BacklEndProyecto.Repositories
{
    public interface IPaymentStatesRepository
    {
        Task<IEnumerable<PaymentStates>> GetAllPaymentStatesAsync();
        Task<PaymentStates> GetPaymentStateByIdAsync(int id);
        Task CreatePaymentStateAsync(PaymentStates paymentState);
        Task DeletePaymentStateAsync(int id);
        Task UpdatePaymentStateAsync(PaymentStates paymentState);
    }

    public class PaymentStatesRepository : IPaymentStatesRepository
    {
        private readonly BackEndDbContext dbContext;

        public PaymentStatesRepository(BackEndDbContext context)
        {
            dbContext = context;
        }

        public async Task CreatePaymentStateAsync(PaymentStates paymentState)
        {
            dbContext.PaymentStates.Add(paymentState);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeletePaymentStateAsync(int id)
        {
            var paymentState = await dbContext.PaymentStates.FindAsync(id);
            if (paymentState != null)
            {
                paymentState.IsDeleted = true;
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<PaymentStates>> GetAllPaymentStatesAsync()
        {
            return await dbContext.PaymentStates.Where(ps => !ps.IsDeleted).ToListAsync();
        }

        public async Task<PaymentStates> GetPaymentStateByIdAsync(int id)
        {
            return await dbContext.PaymentStates.FirstOrDefaultAsync(ps => !ps.IsDeleted && ps.PaymentStateId == id);
        }

        public async Task UpdatePaymentStateAsync(PaymentStates paymentState)
        {
            dbContext.PaymentStates.Update(paymentState);
            await dbContext.SaveChangesAsync();
        }
    }

}
