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

            modelBuilder.Entity<Users>()
            .HasKey( u => u.UserId);

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

            modelBuilder.Entity<AccountTypes>()
            .HasKey(u => u.AccountTypeId);

            modelBuilder.Entity<UserStates>()
            .HasKey(u => u.UserStateId);

            

        }
        
        public DbSet<UserStates> UserStates;
        public DbSet<Users> Users;
        public DbSet<Rols> Rols;
        public DbSet<Produts> Produts;
        public DbSet<ProdutCategories> ProdutCategories;
        public DbSet<Transactions> Transactions;
        public DbSet<TransactionTypes> TransactionTypes;
        public DbSet<Payments> Payments;
        public DbSet<PaymentStates> PaymentStates;
        public DbSet<PaymentMethodsTypes> PaymentMethodsTypes;
        public DbSet<Orders> Orders;
        public DbSet<OrderDetails> OrderDetails;
        public DbSet<Comments> Comments;
        public DbSet<BankAccounts> BankAccounts;
        public DbSet<AccountTypes> AccountTypes;

        // OnModelCreating Tarea
    }
}
