using Ardalis.Specification;
using Domain.Entities;
using Domain.Enums;

namespace Application.Specifications.OutboundsSpecifications;

public class OutboundsByDestinationSpecification : Specification<Outbounds>
{
    public OutboundsByDestinationSpecification(Guid DestinationdId, StatusEnum Status)
    {
        Query.Where(o => o.DestinationId == DestinationdId
        && o.Status == Status)
           .Include(o => o.OutboundDetails)
           .ThenInclude(od => od.ProductBatch)
           .ThenInclude(pb => pb.Product);
    }
}
