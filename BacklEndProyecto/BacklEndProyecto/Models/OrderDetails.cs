using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BacklEndProyecto.Models
{
    [Table("OrderDetails")]
    public class OrderDetails
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderDetailsId { get; set; }
        [ForeignKey("Products")]
        public required int ProductId { get; set; }
        public required int ProductQuantity { get; set; }
        public required string Details { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual Products Produts { get; set; }
    }
}
