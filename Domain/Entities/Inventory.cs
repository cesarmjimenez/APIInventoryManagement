using Domain.Common;

namespace Domain.Entities;

public class Inventory : IdBaseEntity
{
    public required decimal StockQuantity { get; set; }

    public Guid LocationId { get; set; }

    public Locations Location { get; set; } = null!;

    public Guid ProductBatchId { get; set; }

    public ProductBatches ProductBatch { get; set; } = null!;
}
