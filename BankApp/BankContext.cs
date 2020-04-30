using System;
using Microsoft.EntityFrameworkCore;

namespace BankApp
{
    class BankContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        // overriden method: change parents behavior
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost; Initial Catalog=BankApr20; User ID = sa; Password = reallyStrongPwd123;Connect Timeout=30;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Accounts");
                entity.HasKey(a => a.AccountNumber);
                entity.Property(a => a.AccountNumber)
                    .ValueGeneratedOnAdd();

                entity.Property(a => a.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(a => a.AccountName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(a => a.AccountType)
                    .IsRequired();
            });
            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("Transactions");
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Id)
                    .ValueGeneratedOnAdd();
            });
        }
    }
}
