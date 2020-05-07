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
            optionsBuilder.UseSqlServer(@"Data Source = localhost; User Id =sa; Password=reallyStrongPwd123; Initial Catalog = BankApr20; Integrated Security=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(e =>
            {
                e.ToTable("Accounts");
                e.HasKey(a => a.AccountNumber);
                e.Property(a => a.AccountNumber)
                    .ValueGeneratedOnAdd();

                e.Property(a => a.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(250);

                e.Property(a => a.AccountName)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Transaction>(e =>
            {
                e.ToTable("Transactions");
                e.HasKey(t => t.Id);
                e.Property(t => t.Id)
                    .ValueGeneratedOnAdd();
            });
        }
    }
}
