using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BacklEndProyecto.Models
{
    [Table("TransactionTypes")]
    public class TransactionTypes
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionTypeId { get; set; }
        public required string TransactionTypeNames { get; set; }
        public required string Description { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
