using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> builder)
    {
        builder.ToTable("Inventory");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.StockQuantity)
            .HasPrecision(12, 2)
            .IsRequired();

        builder.HasOne(i => i.Location)
            .WithMany()
            .HasForeignKey(i => i.LocationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(i => i.ProductBatch)
            .WithMany()
            .HasForeignKey(i => i.ProductBatchId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
