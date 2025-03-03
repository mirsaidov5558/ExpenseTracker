using System;
using System.Transactions;
using ExpenseTracker.Enums;
using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.UserId)
               .IsRequired();

        builder.Property(t => t.CategoryId)
               .IsRequired();

        builder.Property(t => t.Amount)
               .IsRequired()
               .HasColumnType("decimal(18,2)");

        builder.Property(t => t.Type)
               .HasDefaultValue(TransactionType.Expense);

        builder.Property(t => t.Date)
               .HasDefaultValueSql("GETDATE()");

        builder.Property(t => t.Note)
               .HasMaxLength(500);

        builder.HasOne(t => t.User)
               .WithMany(u => u.Transactions)
               .HasForeignKey(t => t.UserId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(t => t.Category)
               .WithMany(c => c.Transaction)
               .HasForeignKey(t => t.CategoryId)
               .OnDelete(DeleteBehavior.Cascade);
    }

}
