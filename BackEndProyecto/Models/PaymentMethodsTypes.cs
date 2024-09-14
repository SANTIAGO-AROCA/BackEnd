namespace BackEndProyecto.Models
{
    public class PaymentMethodsTypes
    {
        public int PaymentMethodId { get; set; }
        public required string PaymentMethodName { get; set; }
        public string PaymentMethodDescription { get; set; }
    }
}
