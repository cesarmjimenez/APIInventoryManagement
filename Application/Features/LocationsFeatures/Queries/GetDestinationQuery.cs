using Application.DTOs.Locations;
using Application.Interfaces;
using Application.Specifications.LocationsSpecifications;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.LocationsFeatures.Queries;

public class GetDestinationQuery : IRequest<List<LocationsDto>>
{
}

public class GetDestinationQueryHandler(
    IRepositoryAsync<Locations> repositoryAsync,
    IMapper mapper) : IRequestHandler<GetDestinationQuery, List<LocationsDto>>
{
    public async Task<List<LocationsDto>> Handle(GetDestinationQuery request, CancellationToken cancellationToken)
    {
        var spec = new BranchesSpecification();

        List<Locations> locations = await repositoryAsync.ListAsync(spec, cancellationToken);

        return mapper.Map<List<LocationsDto>>(locations);
    }
}
