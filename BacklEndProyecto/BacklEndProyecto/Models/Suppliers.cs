using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BacklEndProyecto.Models
{
    [Table("Suppliers")]
    public class Suppliers
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupplierId { get; set; }
        public required string SupplierName { get; set; }
        public required string SupplierDescription { get; set; }
        [ForeignKey("SupplierState")]
        public required string SupplierState { get; set; }
        public required string SupplierAddress { get; set; }
        public required SuppliersStates SupplierStates { get; set; }
        public required bool IsDeleted { get; set; } = false;   
    }
}
