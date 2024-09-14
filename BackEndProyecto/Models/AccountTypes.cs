using System.ComponentModel.DataAnnotations;

namespace BackEndProyecto.Models
{
    public class AccountTypes
    {
        [Key]
        public required int AccountTypeId { get; set; }
        public required string AccounTypetName { get; set; }
        public string AccountTypeDescription { get; set; }
    }
}
