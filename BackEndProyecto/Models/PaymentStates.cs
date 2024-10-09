using System.ComponentModel.DataAnnotations;

namespace BackEndProyecto.Models
{
    public class PaymentStates
    {
        [Key]
        public int PaymentStateId { get; set; }
        public required string PaymentStatesName { get; set; }
        public required string PaymentStateDescription { get; set; }
        public bool IsDeleted { get; set; } = false;

        // Propiedades de navegacion
    }
}
