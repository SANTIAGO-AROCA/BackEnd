using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BacklEndProyecto.Models
{
    [Table("Transactions")]
    public class Transactions
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }
        [ForeignKey("TransactionTypes")]
        public required int TransactionTypeId { get; set; }
        public required int AccountOrigin { get; set; }
        public required int AccountDestination { get; set; }
        public required int Value { get; set; }
        public required DateTime TransactionDate { get; set; }
        public required string TransactionDescrition { get; set; }
        public bool IsDeleted { get; set; } = false;
        public required virtual TransactionTypes TransactionTypes { get; set; }
    }
}
