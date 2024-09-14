using System.ComponentModel.DataAnnotations;

namespace BackEndProyecto.Models
{
    public class PaymentStates
    {
        [Key]
        public int PaymentStateId { get; set; }
        public required string PaymentStatesName { get; set; }
        public string PaymentStateDescription { get; set; }
    }
}
