using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BacklEndProyecto.Models
{
    [Table("PaymentMethodsTypes")]
    public class PaymentMethodsTypes
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentMethodId { get; set; }
        public required string PaymentMethodName { get; set; }
        public required string PaymentMethodDescription { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
