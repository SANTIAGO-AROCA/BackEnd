using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BacklEndProyecto.Models
{
    [Table("Permissions")]
    public class Permissions
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PermissionId { get; set; }
        public required string RolName { get; set; }
        public required string RolDescription { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
