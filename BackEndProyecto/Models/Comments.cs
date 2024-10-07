using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndProyecto.Models
{
    public class Comments
    {
        [Key]
        public int CommentId { get; set; }
        public required int ProductId { get; set; }
        public required string CommentText { get; set; }
        [ForeignKey("Users")]
        public required int UserId { get; set; }
        public required int CommentType { get; set; }
        public required DateTime CommentDate { get; set; }
        public bool IsDeleted { get; set; } = false;

        //Propiedades de navegacion
        public virtual Users Users { get; set; }
    }
}
