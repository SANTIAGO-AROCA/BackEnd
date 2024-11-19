using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BacklEndProyecto.Models
{
    [Table("Comments")]
    public class Comments
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }
        [ForeignKey("Produts")]
        public required int ProductId { get; set; }
        public required string CommentText { get; set; }
        public required int UserId { get; set; }
        public required int CommentType { get; set; }
        public required DateTime CommentDate { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual Products Produts { get; set; }
    }
}
