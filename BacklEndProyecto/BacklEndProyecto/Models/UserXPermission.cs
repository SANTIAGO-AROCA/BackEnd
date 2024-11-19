using System.ComponentModel.DataAnnotations.Schema;

namespace BacklEndProyecto.Models
{
    public class UserXPermission
    {
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual required UserStates UserStates { get; set; }
        public int PermissionId { get; set; }
        [ForeignKey("PermissionId")]
        public virtual required Permissions Permissions { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
