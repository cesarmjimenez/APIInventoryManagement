using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class LocationsConfiguration : IEntityTypeConfiguration<Locations>
{
    public void Configure(EntityTypeBuilder<Locations> builder)
    {
        builder.ToTable("Locations");

        builder.HasKey(l => l.Id);

        builder.Property(l => l.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(l => l.Address)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(l => l.City)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(l => l.IsWareHouse)
            .IsRequired();

        builder.Property(l => l.IsActive)
            .IsRequired();
    }
}
