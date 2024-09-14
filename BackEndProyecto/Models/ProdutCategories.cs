using System.ComponentModel.DataAnnotations;

namespace BackEndProyecto.Models
{
    public class ProdutCategories
    {
        [Key]
        public required int CategoryId { get; set; }
        public required string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
    }
}
