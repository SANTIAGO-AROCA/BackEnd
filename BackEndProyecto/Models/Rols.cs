using System.ComponentModel.DataAnnotations;

namespace BackEndProyecto.Models
{
    public class Rols
    {
        [Key]
        public int RolsId { get; set; }
        public required string RolName { get; set; }
        public required string RolDescription { get; set; }
        public bool IsDeleted { get; set; } = false;

        // Propiedades de navegacion
    }
}
