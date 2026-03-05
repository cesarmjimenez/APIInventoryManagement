using Domain.Common;

namespace Domain.Entities;

public class ProductBatches : IdBaseEntity
{
    public required string BatchNumber { get; set; }

    public required DateTime ExpirationDate { get; set; }

    public required decimal Quantity { get; set; }

    public required decimal UnitCost { get; set; }

    public Guid ProductId { get; set; }

    public Products Product { get; set; } = null!;

    public Guid LocationId { get; set; }

    public Locations Location { get; set; } = null!;
}
