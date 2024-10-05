using System.ComponentModel.DataAnnotations;

namespace BackEndProyecto.Models
{
    public class Produts
    {
        [Key]
        public required int ProductId { get; set; }
        public required int ProductName { get; set; }
        public required int ProductDescription { get; set; }
        public required int VendorId { get; set; }
        public required int ProductCategoryId { get; set; }
        public required int Price { get; set; }
        public required DateTime CrateDate { get; set; }
        public required int ProductStateId { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
