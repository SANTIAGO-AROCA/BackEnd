using System.ComponentModel.DataAnnotations;

namespace BackEndProyecto.Models
{
    public class TransactionTypes
    {
        [Key]
        public required int TransactionTypeId { get; set; }
        public required string TransactionTypeNames { get; set; }
        public required string Description { get; set; }
        public bool IsDeleted { get; set; } = false;

        // Propiedades de navegacion

    }
}
