﻿using BackEndProyecto.Models;
using BackEndProyecto.Repository;
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

            modelBuilder.Entity<PaymentMethodsTypesRepository>()
            .HasKey(u => u.PaymentMethodId);

            modelBuilder.Entity<Orders>()
            .HasKey(u => u.OrderId);

            modelBuilder.Entity<OrderDetails>()
            .HasKey(u => u.OrderDetailsId);

            modelBuilder.Entity<Comments>()
            .HasKey(u => u.CommentId);

            modelBuilder.Entity<BankAccountsRepository>()
            .HasKey(u => u.AcountId);

            modelBuilder.Entity<AccountTypes>()
            .HasKey(u => u.AccountTypeId);

            modelBuilder.Entity<UserStates>()
            .HasKey(u => u.UserStateId);
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
        public DbSet<PaymentMethodsTypesRepository> PaymentMethodsTypes { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<BankAccountsRepository> BankAccounts { get; set; }
        public DbSet<AccountTypes> AccountTypes { get; set; }
        // OnModelCreating Tarea
    }
}
