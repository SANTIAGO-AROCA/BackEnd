using BacklEndProyecto.Context;
using BacklEndProyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace BacklEndProyecto.Repositories
{
    public interface IPaymentsRepository
    {
        Task<IEnumerable<Payments>> GetAllPaymentsAsync();
        Task<Payments> GetPaymentByIdAsync(int id);
        Task CreatePaymentAsync(Payments payment);
        Task DeletePaymentAsync(int id);
        Task UpdatePaymentAsync(Payments payment);
    }

    public class PaymentsRepository : IPaymentsRepository
    {
        private readonly BackEndDbContext dbContext;

        public PaymentsRepository(BackEndDbContext context)
        {
            dbContext = context;
        }

        public async Task CreatePaymentAsync(Payments payment)
        {
            dbContext.Payments.Add(payment);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeletePaymentAsync(int id)
        {
            var payment = await dbContext.Payments.FindAsync(id);
            if (payment != null)
            {
                payment.IsDeleted = true;
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Payments>> GetAllPaymentsAsync()
        {
            return await dbContext.Payments.Where(p => !p.IsDeleted).ToListAsync();
        }

        public async Task<Payments> GetPaymentByIdAsync(int id)
        {
            return await dbContext.Payments.FirstOrDefaultAsync(p => !p.IsDeleted && p.PaymentId == id);
        }

        public async Task UpdatePaymentAsync(Payments payment)
        {
            dbContext.Payments.Update(payment);
            await dbContext.SaveChangesAsync();
        }
    }

}
