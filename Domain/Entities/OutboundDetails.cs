using Domain.Common;

namespace Domain.Entities;

public class OutboundDetails : IdBaseEntity
{
    public required decimal Quantity { get; set; }

    public required decimal SubTotal { get; set; }

    public Guid OutboundId { get; set; }

    public Outbounds Outbound { get; set; } = null!;

    public Guid ProductBatchId { get; set; }

    public ProductBatches ProductBatch { get; set; } = null!;
}
