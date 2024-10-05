using System.ComponentModel.DataAnnotations;

namespace BackEndProyecto.Models
{
    public class UserStates
    {
        [Key]
        public int UserStateId { get; set; }
        public required string UserStateName { get; set; }
        public string UserStateDescription { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
