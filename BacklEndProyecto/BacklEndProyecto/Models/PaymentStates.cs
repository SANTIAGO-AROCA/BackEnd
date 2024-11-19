using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BacklEndProyecto.Models
{
    [Table("PaymentStates")]
    public class PaymentStates
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentStateId { get; set; }
        public required string PaymentStatesName { get; set; }
        public required string PaymentStateDescription { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
