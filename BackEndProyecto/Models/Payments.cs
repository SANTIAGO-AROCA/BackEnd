namespace BackEndProyecto.Models
{
    public class Payments
    {
        public int PaymentId { get; set; }
        public required int PaymentType { get; set; }
        public required int AccountId { get; set; }
        public required int PaymentMethodType { get; set; }
        public required DateTime PayDate { get; set; }
        public required int PaymentState { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
