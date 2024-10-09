using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [ForeignKey("Rols")]
        public required int RolID { get; set; }
        [ForeignKey("UserStates")]
        public required int StateID { get; set;}
        public bool IsDeleted { get; set; } = false;

        //Propiedades de navegacion
        public virtual BankAccounts BankAccount { get; set; }
        public virtual Rols Rols { get; set; }

        public virtual UserStates UserStates { get; set; }




    }
}
