using System.ComponentModel.DataAnnotations;

namespace BackEndProyecto.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderDetailsId { get; set; }
        public required int ProductId { get; set; }
        public required int ProductQuantity { get; set; }
        public required int Details {  get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
