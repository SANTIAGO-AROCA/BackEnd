using System.ComponentModel.DataAnnotations;

namespace BackEndProyecto.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string city { get; set; }
        public required string address { get; set; }
        public required string phone { get; set; }
    }
}
