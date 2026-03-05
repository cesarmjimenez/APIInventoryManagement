using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class OutboundsConfiguration : IEntityTypeConfiguration<Outbounds>
{
    public void Configure(EntityTypeBuilder<Outbounds> builder)
    {
        builder.ToTable("Outbounds");

        builder.HasKey(o => o.Id);

        builder.Property(o => o.OutboundNumber)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(o => o.OutboundNumber)
            .IsUnique();

        builder.Property(o => o.Status)
            .HasConversion<string>()
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(o => o.OutboundDate)
            .IsRequired();

        builder.Property(o => o.ReceivedDate)
            .IsRequired(false);

        builder.HasOne(o => o.OriginLocation)
            .WithMany()
            .HasForeignKey(o => o.OriginLocationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(o => o.Destination)
            .WithMany()
            .HasForeignKey(o => o.DestinationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(o => o.OutboundUser)
            .WithMany()
            .HasForeignKey(o => o.OutboundUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(o => o.ReceivedUser)
            .WithMany()
            .HasForeignKey(o => o.ReceivedUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
