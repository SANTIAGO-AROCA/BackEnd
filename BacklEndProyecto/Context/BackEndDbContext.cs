using BacklEndProyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace BacklEndProyecto.Context
{
    public class BackEndDbContext : DbContext
    {
        public BackEndDbContext(DbContextOptions options) : base(options) { }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<BankAccounts> BankAccounts { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<PaymentMethodsTypes> PaymentMethodsTypes { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<PaymentStates> PaymentStates { get; set; }
        public DbSet<ProductCategories> ProductCategories { get; set; }
        public DbSet<ProductsStates> ProductsStates { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<SuppliersStates> SuppliersStates { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<TransactionTypes> TransactionTypes { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserStates> UserStates { get; set; }
        public DbSet<UserXPermission> UserXper { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<UserXPermission>()
                .HasKey(up => new { up.UserId, up.PermissionId });
        }
    }
}
