using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    public DbSet<Inventory> Inventory { get; set; }

    public DbSet<Locations> Locations { get; set; }

    public DbSet<OutboundDetails> OutboundDetails { get; set; }

    public DbSet<Outbounds> Outbounds { get; set; }

    public DbSet<ProductBatches> ProductBatches { get; set; }

    public DbSet<Products> Products { get; set; }

    public DbSet<Roles> Roles { get; set; }

    public DbSet<Users> Users { get; set; }
}
