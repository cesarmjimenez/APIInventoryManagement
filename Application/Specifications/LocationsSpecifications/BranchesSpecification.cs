using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specifications.LocationsSpecifications;

public class BranchesSpecification : Specification<Locations>
{
    public BranchesSpecification()
    {
        Query.Where(l => !l.IsWareHouse)
            .Where(l => l.IsActive);

        Query.OrderBy(l => l.Name);
    }
}
