using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specifications.ProductBatchesSpecifications;

public class BatchesByProductIdSpecification : Specification<ProductBatches>
{
    public BatchesByProductIdSpecification(Guid ProductId)
    {
        Query.Where(pb => pb.ProductId == ProductId)
            .Include(pb => pb.Product);
    }
}
