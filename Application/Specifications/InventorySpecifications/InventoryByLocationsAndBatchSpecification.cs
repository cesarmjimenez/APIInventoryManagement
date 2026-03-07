using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specifications.InventorySpecifications;

public class InventoryByLocationsAndBatchSpecification : Specification<Inventory>
{
    public InventoryByLocationsAndBatchSpecification(Guid LocationId, Guid ProductBatchId)
    {
        Query.Where(i => i.LocationId == LocationId && i.ProductBatchId == ProductBatchId);
    }
}
