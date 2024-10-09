namespace BackEndProyecto.Models
{
    public class PaymentMethodsTypesRepository
    {
        public int PaymentMethodId { get; set; }
        public required string PaymentMethodName { get; set; }
        public string PaymentMethodDescription { get; set; }
    }
}
