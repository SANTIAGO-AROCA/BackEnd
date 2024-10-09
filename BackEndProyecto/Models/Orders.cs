using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndProyecto.Models
{
    public class Orders
    {
        [Key]
        public required int OrderId { get; set; }
        [ForeignKey("Users")]
        public required int UserId { get; set; }
        public required int OrderDetailsId { get; set; }
        public required DateTime OrderDate { get; set; }
        [ForeignKey("Payments")]
        public required int PaymentId { get; set; }
        public bool IsDeleted { get; set; } = false;
        // Propiedades de navegacion

        public virtual Users users { get; set; }

        public virtual Payments Payments { get; set; }
    }
}
