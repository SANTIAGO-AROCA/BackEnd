using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BackEndProyecto.Models
{
    public class BankAccounts
    {
        [Key]
        public required int AcountId { get; set; }
        [ForeignKey("Users")]
        public required int UserId { get; set; }
        public required int AcountNumber { get; set; }
        [ForeignKey("AccountTypes")]
        public required int AccountTypeId {  get; set; }
        public required float Balance { get; set; }
        public required int movements { get; set; }
        public required DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; } = false;

        // Propiedades de navegación
        public  Users Users { get; set; }
        public AccountType AccountType { get; set; }
    }
}
