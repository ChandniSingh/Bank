using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
   public class BankModel : DbContext

    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Transaction> Transactions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Bank;Integrated Security=True;Connect Timeout=30");


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.AccountNumber)
                .HasName("PK_Accounts");
                entity.Property(e => e.AccountNumber)
                .ValueGeneratedOnAdd();
                entity.Property(e => e.EmailAddress)
                .IsRequired()
                .HasMaxLength(50);

            });



            {
                modelBuilder.Entity<Transaction>(entity =>
                {
                    entity.HasKey(e => e.TransactionId)
                    .HasName("PK_Transaction");
                    entity.Property(e => e.TransactionId)
                    .ValueGeneratedOnAdd();


                });
            }
        }
    }
}


