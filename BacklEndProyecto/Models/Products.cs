using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BacklEndProyecto.Models
{
    [Table("Products")]
    public class Products
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [ForeignKey("Users")]
        public required int VendorId { get; set; }
        public required string ProductName { get; set; }
        public required string ProductDescription { get; set; }
        [ForeignKey("Suppliers")]
        public required int SupplierId { get; set; }
        [ForeignKey("ProductCategories")]
        public required int ProductCategoryId { get; set; }
        public required int Price { get; set; }
        public required DateTime CrateDate { get; set; }
        [ForeignKey("ProductsStates")]
        public required int ProductStateId { get; set; }
        [ForeignKey("TransactionTypes")]
        public required int TransactionTypesId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual ProductCategories ProdutCategories { get; set; }
        public virtual ProductsStates ProductsStates { get; set; }
        public virtual Users users { get; set; }
        public virtual TransactionTypes TransactionTypes { get; set; }
        public virtual Suppliers Suppliers { get; set; }
    }
}
