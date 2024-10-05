using System.ComponentModel.DataAnnotations;

namespace BackEndProyecto.Models
{
    public class Orders
    {
        [Key]
        public required int OrderId { get; set; }
        public required int UserId { get; set; }
        public required int OrderDetailsId { get; set; }
        public required DateTime OrderDate { get; set; }
        public required int PaymentId { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
