using BacklEndProyecto.Models;
using BacklEndProyecto.Repositories;

namespace BacklEndProyecto.Services
{
    public interface IPaymentsService
    {
        Task<IEnumerable<Payments>> GetAllPaymentsAsync();
        Task<Payments> GetPaymentByIdAsync(int id);
        Task CreatePaymentAsync(Payments payment);
        Task DeletePaymentAsync(int id);
        Task UpdatePaymentAsync(Payments payment);
    }

    public class PaymentsService : IPaymentsService
    {
        private readonly IPaymentsRepository _paymentsRepository;

        public PaymentsService(IPaymentsRepository repository)
        {
            _paymentsRepository = repository;
        }

        public Task CreatePaymentAsync(Payments payment)
        {
            return _paymentsRepository.CreatePaymentAsync(payment);
        }

        public Task DeletePaymentAsync(int id)
        {
            return _paymentsRepository.DeletePaymentAsync(id);
        }

        public Task<IEnumerable<Payments>> GetAllPaymentsAsync()
        {
            return _paymentsRepository.GetAllPaymentsAsync();
        }

        public Task<Payments> GetPaymentByIdAsync(int id)
        {
            return _paymentsRepository.GetPaymentByIdAsync(id);
        }

        public Task UpdatePaymentAsync(Payments payment)
        {
            return _paymentsRepository.UpdatePaymentAsync(payment);
        }
    }

}
