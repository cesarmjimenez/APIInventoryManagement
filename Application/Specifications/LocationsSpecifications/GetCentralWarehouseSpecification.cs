using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specifications.LocationsSpecifications;

public class GetCentralWarehouseSpecification : Specification<Locations>
{
    public GetCentralWarehouseSpecification()
    {
        Query.Where(l => l.Name == "Bodega Central");
    }
}
