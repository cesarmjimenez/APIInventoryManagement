using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class OutboundDetailsConfiguration : IEntityTypeConfiguration<OutboundDetails>
{
    public void Configure(EntityTypeBuilder<OutboundDetails> builder)
    {
        builder.ToTable("OutboundDetails");

        builder.HasKey(od => od.Id);

        builder.Property(od => od.Quantity)
            .HasPrecision(12, 2)
            .IsRequired();

        builder.Property(od => od.SubTotal)
            .HasPrecision(12, 2)
            .IsRequired();

        builder.HasOne(od => od.Outbound)
            .WithMany(o => o.OutboundDetails)
            .HasForeignKey(od => od.OutboundId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(od => od.ProductBatch)
            .WithMany()
            .HasForeignKey(od => od.ProductBatchId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
