using System.ComponentModel.DataAnnotations;

namespace BackEndProyecto.Models
{
    public class AccountType
    {
        [Key]
        public required int AccountTypeId { get; set; }
        public required string AccounTypetName { get; set; }
        public required string AccountTypeDescription { get; set; }
        public bool IsDeleted { get; set; } = false;

        // Propiedades de navegación Uno a muchos
        //public virtual required ICollection<BankAccounts> BankAccounts { get; set; }
    }
}
