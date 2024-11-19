using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BacklEndProyecto.Models
{
    [Table("ProductCategories")]
    public class ProductCategories
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        public required string CategoryName { get; set; }
        public required string CategoryDescription { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
