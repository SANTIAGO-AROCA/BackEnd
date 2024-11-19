using BacklEndProyecto.Models;
using BacklEndProyecto.Repositories;

namespace BacklEndProyecto.Services
{
    public interface IPaymentStatesService
    {
        Task<IEnumerable<PaymentStates>> GetAllPaymentStatesAsync();
        Task<PaymentStates> GetPaymentStateByIdAsync(int id);
        Task CreatePaymentStateAsync(PaymentStates paymentState);
        Task DeletePaymentStateAsync(int id);
        Task UpdatePaymentStateAsync(PaymentStates paymentState);
    }

    public class PaymentStatesService : IPaymentStatesService
    {
        private readonly IPaymentStatesRepository _paymentStatesRepository;

        public PaymentStatesService(IPaymentStatesRepository repository)
        {
            _paymentStatesRepository = repository;
        }

        public Task CreatePaymentStateAsync(PaymentStates paymentState)
        {
            return _paymentStatesRepository.CreatePaymentStateAsync(paymentState);
        }

        public Task DeletePaymentStateAsync(int id)
        {
            return _paymentStatesRepository.DeletePaymentStateAsync(id);
        }

        public Task<IEnumerable<PaymentStates>> GetAllPaymentStatesAsync()
        {
            return _paymentStatesRepository.GetAllPaymentStatesAsync();
        }

        public Task<PaymentStates> GetPaymentStateByIdAsync(int id)
        {
            return _paymentStatesRepository.GetPaymentStateByIdAsync(id);
        }

        public Task UpdatePaymentStateAsync(PaymentStates paymentState)
        {
            return _paymentStatesRepository.UpdatePaymentStateAsync(paymentState);
        }
    }

}
