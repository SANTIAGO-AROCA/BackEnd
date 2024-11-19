using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BacklEndProyecto.Models
{
    [Table("Users")]
    public class Users
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Passcode { get; set; }
        public required string City { get; set; }
        public required string Address { get; set; }
        public required string Phone { get; set; }
        [ForeignKey("Rols")]
        public required int RolID { get; set; }
        [ForeignKey("UserStates")]
        public required int StateID { get; set; }
        public bool IsDeleted { get; set; } = false;

        public required virtual Permissions Rols { get; set; }

        public required virtual UserStates UserStates { get; set; }
    }
}
