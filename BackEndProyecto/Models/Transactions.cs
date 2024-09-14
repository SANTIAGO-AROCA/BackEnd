using System.ComponentModel.DataAnnotations;

namespace BackEndProyecto.Models
{
    public class Transactions
    {
        [Key]
        public required int TransactionId { get; set; }
        public required int TransactionTypeId { get; set; }
        public required int AccountOrigin {  get; set; }
        public required int AccountDestination { get; set; }
        public required int Value { get; set; }
        public required DateTime TransactionDate { get; set; }
        public string TransactionDescrition { get; set; }
    }
}
