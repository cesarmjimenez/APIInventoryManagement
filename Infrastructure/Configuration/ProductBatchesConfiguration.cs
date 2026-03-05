using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class ProductBatchesConfiguration : IEntityTypeConfiguration<ProductBatches>
{
    public void Configure(EntityTypeBuilder<ProductBatches> builder)
    {
        builder.ToTable("ProductBatches");

        builder.HasKey(pb => pb.Id);

        builder.Property(pb => pb.BatchNumber)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(pb => pb.BatchNumber)
            .IsUnique();

        builder.Property(pb => pb.ExpirationDate)
            .IsRequired();

        builder.Property(pb => pb.Quantity)
            .HasPrecision(12, 2)
            .IsRequired();

        builder.Property(pb => pb.UnitCost)
            .HasPrecision(12, 2)
            .IsRequired();

        builder.HasOne(pb => pb.Product)
            .WithMany()
            .HasForeignKey(pb => pb.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(pb => pb.Location)
            .WithMany()
            .HasForeignKey(pb => pb.LocationId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
