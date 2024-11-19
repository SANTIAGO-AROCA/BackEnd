using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BacklEndProyecto.Models
{
    [Table("SuppliersStates")]
    public class SuppliersStates
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupplierStateId { get; set; }
        public required string SupplierState { get; set; }
        public required string SupplierStateDescription { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
