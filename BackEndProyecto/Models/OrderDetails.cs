using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndProyecto.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderDetailsId { get; set; }
        [ForeignKey("Products")]
        public required int ProductId { get; set; }
        public required int ProductQuantity { get; set; }
        public required string Details {  get; set; }
        public bool IsDeleted { get; set; } = false;

        // Propiedades de navegacion
        public virtual Produts Produts { get; set; }
    }
}
