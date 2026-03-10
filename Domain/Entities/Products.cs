using Domain.Common;

namespace Domain.Entities;

public class Products : IdBaseEntity
{
    public required string Sku { get; set; }

    public required string Name { get; set; }

    public required string Brand { get; set; }

    public bool IsActive { get; set; }

    public ICollection<ProductBatches> ProductBatches { get; set; } = [];
}
