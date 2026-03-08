using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specifications.OutboundsSpecifications;

public class OutboundsWithFiltersSpecification : Specification<Outbounds>
{
    public OutboundsWithFiltersSpecification(DateTime? fromDate, DateTime? toDate, Guid? destinationId)
    {
        if (destinationId.HasValue)
        {
            Query.Where(o => o.DestinationId == destinationId);
        }

        if (fromDate.HasValue)
        {
            Query.Where(o => o.OutboundDate >= fromDate.Value);
        }

        if (toDate.HasValue)
        {
            Query.Where(o => o.OutboundDate <= toDate.Value);
        }

        Query.Include(o => o.ReceivedUser);

        Query.Include(o => o.OutboundDetails)
            .ThenInclude(od => od.ProductBatch);

        Query.OrderByDescending(o => o.OutboundDate);
    }
}
