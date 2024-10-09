using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndProyecto.Models
{
    public class Payments
    {
        [Key]
        public int PaymentId { get; set; }
        public required int PaymentType { get; set; }
        public required int AccountId { get; set; }
        [ForeignKey("PaymentMethodsTypes")]
        public required int PaymentMethodTypeID { get; set; }
        public required DateTime PayDate { get; set; }
        [ForeignKey("PaymentStates")]
        public required int PaymentState { get; set; }
        public bool IsDeleted { get; set; } = false;

        // Propiedades de navegacion
        public virtual PaymentStates PaymentStates { get; set; }

        public virtual PaymentMethodsTypes PaymentMethodsTypes { get; set; }
    }
}
