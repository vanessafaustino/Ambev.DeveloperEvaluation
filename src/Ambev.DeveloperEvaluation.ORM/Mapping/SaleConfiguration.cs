using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");

        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id)
            .HasColumnType("uuid")
            .HasDefaultValueSql("gen_random_uuid()");

        builder.Property(s => s.CreatedAt)
            .HasColumnType("timestamp")
            .HasDefaultValueSql("now()");

        builder.Property(s => s.UpdatedAt)
            .HasColumnType("timestamp")
            .HasDefaultValueSql("now()")
            .ValueGeneratedOnUpdate();

        builder.Property(s => s.SaleNumber)
            .IsRequired();

        builder.Property(s => s.TotalAmount)
            .HasColumnType("decimal(18,2)");

        builder.Property(s => s.Status)
            .IsRequired();

        builder.HasOne(s => s.Customer)
            .WithMany()
            .HasForeignKey("CustomerId")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(s => s.Branch)
            .WithMany()
            .HasForeignKey("BranchId")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(s => s.Products)
            .WithOne()
            .HasForeignKey("SaleId")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
