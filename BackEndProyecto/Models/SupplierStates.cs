using System.ComponentModel.DataAnnotations;

namespace BackEndProyecto.Models
{
    public class SupplierStates
    {
        [Key]
        public int SupplierStateId { get; set; }
        public required string SupplierState { get; set; }
        public string SupplierStateDescription { get; set; }

        // Propiedades de navegacion
        public virtual ICollection<Suppliers> Suppliers { get; set; }
    }
}
