using Application.DTOs.ProductsDtos;
using Application.Interfaces;
using Application.Specifications.ProductsSpecifications;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductsFeatures.Queries;

public class GetActiveProductsQuery : IRequest<List<ProductsDto>>
{
}

public class GetActiveProductsQueryHandler(
    IRepositoryAsync<Products> repositoryAsync,
    IMapper mapper) : IRequestHandler<GetActiveProductsQuery, List<ProductsDto>>
{
    public async Task<List<ProductsDto>> Handle(GetActiveProductsQuery request, CancellationToken cancellationToken)
    {
        var spec = new GetActiveProductsSpecification();

        List<Products> products = await repositoryAsync.ListAsync(spec, cancellationToken);

        return mapper.Map<List<ProductsDto>>(products);
    }
}
