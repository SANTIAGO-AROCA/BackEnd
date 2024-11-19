using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BacklEndProyecto.Models
{
    [Table("AccountType")]
    public class AccountType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountTypeId { get; set; }
        public required string AccounTypetName { get; set; }
        public required string AccountTypeDescription { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
