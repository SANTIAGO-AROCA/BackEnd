using BacklEndProyecto.Context;
using BacklEndProyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace BacklEndProyecto.Repositories
{
    public interface IPaymentMethodsTypesRepository
    {
        Task<IEnumerable<PaymentMethodsTypes>> GetAllPaymentMethodsAsync();
        Task<PaymentMethodsTypes> GetPaymentMethodByIdAsync(int id);
        Task CreatePaymentMethodAsync(PaymentMethodsTypes paymentMethod);
        Task DeletePaymentMethodAsync(int id);
        Task UpdatePaymentMethodAsync(PaymentMethodsTypes paymentMethod);
    }

    public class PaymentMethodsTypesRepository : IPaymentMethodsTypesRepository
    {
        private readonly BackEndDbContext dbContext;

        public PaymentMethodsTypesRepository(BackEndDbContext context)
        {
            dbContext = context;
        }

        public async Task CreatePaymentMethodAsync(PaymentMethodsTypes paymentMethod)
        {
            dbContext.PaymentMethodsTypes.Add(paymentMethod);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeletePaymentMethodAsync(int id)
        {
            var paymentMethod = await dbContext.PaymentMethodsTypes.FindAsync(id);
            if (paymentMethod != null)
            {
                paymentMethod.IsDeleted = true;
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<PaymentMethodsTypes>> GetAllPaymentMethodsAsync()
        {
            return await dbContext.PaymentMethodsTypes.Where(pm => !pm.IsDeleted).ToListAsync();
        }

        public async Task<PaymentMethodsTypes> GetPaymentMethodByIdAsync(int id)
        {
            return await dbContext.PaymentMethodsTypes.FirstOrDefaultAsync(pm => !pm.IsDeleted && pm.PaymentMethodId == id);
        }

        public async Task UpdatePaymentMethodAsync(PaymentMethodsTypes paymentMethod)
        {
            dbContext.PaymentMethodsTypes.Update(paymentMethod);
            await dbContext.SaveChangesAsync();
        }
    }

}
