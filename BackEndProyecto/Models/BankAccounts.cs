using System.ComponentModel.DataAnnotations;
namespace BackEndProyecto.Models
{
    public class BankAccountsRepository
    {
        [Key]
        public required int AcountId { get; set; }
        public required int UsertId { get; set; }
        public required int AcountNumber { get; set; }
        public required int AccountType {  get; set; }
        public required decimal Balance { get; set; }
        public required int movements { get; set; }
        public required DateTime CreationDate { get; set; }
    }
}
