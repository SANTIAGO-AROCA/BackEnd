using System.ComponentModel.DataAnnotations;

namespace BackEndProyecto.Models
{
    public class Users
    {
        [Key]
        int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }

    }
}
