using System.ComponentModel.DataAnnotations;

namespace BackEndProyecto.Models
{
    public class Comments
    {
        [Key]
        public int CommentId { get; set; }
        public required int ProductId { get; set; }
        public required string CommentText { get; set; }
        public required int UserId { get; set; }
        public required int CommentType { get; set; }
        public required DateTime CommentDate { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
