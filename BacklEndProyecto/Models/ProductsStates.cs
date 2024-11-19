using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BacklEndProyecto.Models
{
    [Table("ProductsStates")]
    public class ProductsStates
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int ProductStateId { get; set; }
        public required string ProductStateName { get; set; }
        public required string ProductStateDescription { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
