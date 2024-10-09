using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndProyecto.Models
{
    public class Transactions
    {
        [Key]
        public required int TransactionId { get; set; }
        [ForeignKey("TransactionTypes")]
        public required int TransactionTypeId { get; set; }
        public required int AccountOrigin {  get; set; }
        public required int AccountDestination { get; set; }
        public required int Value { get; set; }
        public required DateTime TransactionDate { get; set; }
        public required string TransactionDescrition { get; set; }
        public bool IsDeleted { get; set; } = false;

        // Propiedades de navegacion
        public virtual TransactionTypes TransactionTypes { get; set; }
    }
}
