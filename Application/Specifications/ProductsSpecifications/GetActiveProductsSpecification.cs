using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specifications.ProductsSpecifications;

public class GetActiveProductsSpecification : Specification<Products>
{
    public GetActiveProductsSpecification()
    {
        Query.Where(p => p.IsActive)
            .Include(p => p.ProductBatches);
    }
}
