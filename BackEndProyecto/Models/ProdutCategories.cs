using System.ComponentModel.DataAnnotations;

namespace BackEndProyecto.Models
{
    public class ProdutCategories
    {
        [Key]
        public required int CategoryId { get; set; }
        public required string CategoryName { get; set; }
        public required string CategoryDescription { get; set; }
        public bool IsDeleted { get; set; } = false;

        // Propiedades de navegacion
    }
}
