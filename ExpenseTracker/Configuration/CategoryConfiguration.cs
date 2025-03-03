using System;
using ExpenseTracker.Enums;
using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
	public void Configure(EntityTypeBuilder<Category> builder)
	{
		builder.HasKey(c => c.Id);

        builder.Property(c => c.UserId)
                   .IsRequired();

        builder.Property(c => c.Type)
               .HasDefaultValue(TransactionType.Expense);

        builder.HasOne(c => c.User)
               .WithMany(u => u.Categories)
               .HasForeignKey(c => c.UserId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Transaction)
               .WithOne(t => t.Category)
               .HasForeignKey(t => t.CategoryId)
               .OnDelete(DeleteBehavior.Cascade);
    }
	
}
