using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BacklEndProyecto.Models
{
    [Table("UserStates")]
    public class UserStates
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserStateId { get; set; }
        public required string UserStateName { get; set; }
        public required string UserStateDescription { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
