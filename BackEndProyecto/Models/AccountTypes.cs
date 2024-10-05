using System.ComponentModel.DataAnnotations;

namespace BackEndProyecto.Models
{
    public class AccountTypes
    {
        [Key]
        public required int AccountTypeId { get; set; }
        public required string AccounTypetName { get; set; }
        public string AccountTypeDescription { get; set; }
        public bool IsDeleted { get; set; } = false;

        // Propiedades de navegación Uno a muchos
        public virtual ICollection<BankAccounts> BankAccounts { get; set; }
    }
}
