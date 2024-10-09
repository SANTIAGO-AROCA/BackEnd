using BackEndProyecto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BackEndProyecto.Context
{
    public class dbcontextBank : DbContext
    {
        public dbcontextBank(DbContextOptions options): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Llaves primarias
            modelBuilder.Entity<Users>()
            .HasKey(u => u.UserId);

            modelBuilder.Entity<Rols>()
            .HasKey(u => u.RolsId);

            modelBuilder.Entity<Produts>()
            .HasKey(u => u.ProductId);

            modelBuilder.Entity<ProdutCategories>()
            .HasKey(u => u.CategoryId);

            modelBuilder.Entity<Transactions>()
            .HasKey(u => u.TransactionId);

            modelBuilder.Entity<TransactionTypes>()
            .HasKey(u => u.TransactionTypeId);

            modelBuilder.Entity<Payments>()
            .HasKey(u => u.PaymentId);

            modelBuilder.Entity<PaymentStates>()
            .HasKey(u => u.PaymentStateId);

            modelBuilder.Entity<PaymentMethodsTypes>()
            .HasKey(u => u.PaymentMethodId);

            modelBuilder.Entity<Orders>()
            .HasKey(u => u.OrderId);

            modelBuilder.Entity<OrderDetails>()
            .HasKey(u => u.OrderDetailsId);

            modelBuilder.Entity<Comments>()
            .HasKey(u => u.CommentId);

            modelBuilder.Entity<BankAccounts>()
            .HasKey(u => u.AcountId);

            modelBuilder.Entity<AccountType>()
            .HasKey(u => u.AccountTypeId);

            modelBuilder.Entity<UserStates>()
            .HasKey(u => u.UserStateId);

            modelBuilder.Entity<Suppliers>()
            .HasKey(u => u.SupplierId);

            modelBuilder.Entity<SupplierStates>()
            .HasKey(u => u.SupplierStateId);

            // Configurar la relación uno a uno entre Users y BankAccounts
            modelBuilder.Entity<Users>()
            .HasOne(u => u.BankAccount)
            .WithOne(b => b.Users)
            .HasForeignKey<BankAccounts>(b => b.UserId);

            //Configuracion relacion uno a muchos entre BankAccounts y AccountTypes 
            modelBuilder.Entity<BankAccounts>()
            .HasOne(u => u.AccountType)
            .WithMany(s => s.BankAccounts)
            .HasForeignKey(b => b.AccountTypeId);

            // Configuracion relacion uno a muchos entrEe Suppliers y SupplierStates
            modelBuilder.Entity<Suppliers>()
            .HasOne(b => b.SupplierStates)
            .WithMany(a => a.Suppliers)
            .HasForeignKey(b => b.SupplierId);

            
        }

        public DbSet<Users> users { get; set; }
        public DbSet<UserStates> UserStates { get; set; }
        public DbSet<Rols> Rols { get; set; }
        public DbSet<Produts> Produts { get; set; }
        public DbSet<ProdutCategories> ProdutCategories { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<TransactionTypes> TransactionTypes { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<PaymentStates> PaymentStates { get; set; }
        public DbSet<PaymentMethodsTypes> PaymentMethodsTypes { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<BankAccounts> BankAccounts { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        
    }
}
