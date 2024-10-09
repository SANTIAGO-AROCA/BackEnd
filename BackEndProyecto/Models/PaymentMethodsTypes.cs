namespace BackEndProyecto.Models
{
    public class PaymentMethodsTypes
    {
        public int PaymentMethodId { get; set; }
        public required string PaymentMethodName { get; set; }
        public required string PaymentMethodDescription { get; set; }
        public bool IsDeleted { get; set; } = false;
        // Propiedades de navegacion
    }
}
