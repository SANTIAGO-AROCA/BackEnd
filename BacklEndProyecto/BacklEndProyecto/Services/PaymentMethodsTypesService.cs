using BacklEndProyecto.Models;
using BacklEndProyecto.Repositories;

namespace BacklEndProyecto.Services
{
    public interface IPaymentMethodsTypesService
    {
        Task<IEnumerable<PaymentMethodsTypes>> GetAllPaymentMethodsAsync();
        Task<PaymentMethodsTypes> GetPaymentMethodByIdAsync(int id);
        Task CreatePaymentMethodAsync(PaymentMethodsTypes paymentMethod);
        Task DeletePaymentMethodAsync(int id);
        Task UpdatePaymentMethodAsync(PaymentMethodsTypes paymentMethod);
    }

    public class PaymentMethodsTypesService : IPaymentMethodsTypesService
    {
        private readonly IPaymentMethodsTypesRepository _paymentMethodsRepository;

        public PaymentMethodsTypesService(IPaymentMethodsTypesRepository repository)
        {
            _paymentMethodsRepository = repository;
        }

        public Task CreatePaymentMethodAsync(PaymentMethodsTypes paymentMethod)
        {
            return _paymentMethodsRepository.CreatePaymentMethodAsync(paymentMethod);
        }

        public Task DeletePaymentMethodAsync(int id)
        {
            return _paymentMethodsRepository.DeletePaymentMethodAsync(id);
        }

        public Task<IEnumerable<PaymentMethodsTypes>> GetAllPaymentMethodsAsync()
        {
            return _paymentMethodsRepository.GetAllPaymentMethodsAsync();
        }

        public Task<PaymentMethodsTypes> GetPaymentMethodByIdAsync(int id)
        {
            return _paymentMethodsRepository.GetPaymentMethodByIdAsync(id);
        }

        public Task UpdatePaymentMethodAsync(PaymentMethodsTypes paymentMethod)
        {
            return _paymentMethodsRepository.UpdatePaymentMethodAsync(paymentMethod);
        }
    }

}
