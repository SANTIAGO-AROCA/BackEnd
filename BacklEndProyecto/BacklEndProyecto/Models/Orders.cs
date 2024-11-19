using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BacklEndProyecto.Models
{
    [Table("Orders")]
    public class Orders
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        [ForeignKey("Users")]
        public required int UserId { get; set; }
        public required int OrderDetailsId { get; set; }
        public required DateTime OrderDate { get; set; }
        [ForeignKey("Payments")]
        public required int PaymentId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual Users users { get; set; }
        public virtual Payments Payments { get; set; }
    }
}
