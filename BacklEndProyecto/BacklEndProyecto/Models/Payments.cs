using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BacklEndProyecto.Models
{
    [Table("Payments")]
    public class Payments
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentId { get; set; }
        public required int PaymentType { get; set; }
        public required int AccountId { get; set; }
        [ForeignKey("PaymentMethodsTypes")]
        public required int PaymentMethodTypeID { get; set; }
        public required DateTime PayDate { get; set; }
        [ForeignKey("PaymentStates")]
        public required int PaymentState { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual required PaymentStates PaymentStates { get; set; }
        public virtual required PaymentMethodsTypes PaymentMethodsTypes { get; set; }
    }
}
