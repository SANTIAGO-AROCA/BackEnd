﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndProyecto.Models
{
    public class Produts
    {
        [Key]
        public required int ProductId { get; set; }
        [ForeignKey("Users")]
        public required int VendorId { get; set; }
        public required int ProductName { get; set; }
        public required String ProductDescription { get; set; }
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

        // Propiedades de navegacion
        public virtual ProdutCategories ProdutCategories { get; set; }
        public virtual ProductsStates ProductsStates { get; set; }

        public virtual Users users { get; set; }

        public virtual TransactionTypes TransactionTypes { get; set; }

        public virtual Suppliers Suppliers { get; set; }

    }
}
