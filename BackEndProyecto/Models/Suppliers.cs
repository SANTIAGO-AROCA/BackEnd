using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndProyecto.Models
{
    public class Suppliers
    {
        [Key]
        public int SupplierId { get; set; }
        public required string SupplierName { get; set; }
        public string SupplierDescription { get; set; }
        [ForeignKey("SupplierState")]
        public required string SupplierState { get; set; }
        public required string SupplierAddress { get; set; }

        //Propiedades navegacion
        public SupplierStates SupplierStates { get; set; }
    }
}