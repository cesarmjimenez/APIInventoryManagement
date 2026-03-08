using Application.DTOs.OutboundsDtos;
using Application.Interfaces;
using Application.Specifications.OutboundsSpecifications;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.OutboundsFeatures.Queries;

public class GetOutboundsQuery : IRequest<List<OutboundListDto>>
{
    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public Guid? DestinationId { get; set; }
}

public class GetOutboundsQueryHandler(
    IRepositoryAsync<Outbounds> repositoryAsync,
    IMapper mapper) : IRequestHandler<GetOutboundsQuery, List<OutboundListDto>>
{
    public async Task<List<OutboundListDto>> Handle(GetOutboundsQuery request, CancellationToken cancellationToken)
    {
        var outbounds = await repositoryAsync.ListAsync(new OutboundsWithFiltersSpecification(
            request.FromDate,
            request.ToDate,
            request.DestinationId), cancellationToken);

        var result = outbounds.Select(o => new OutboundListDto
        {
            Id = o.Id,
            OutboundNumber = o.OutboundNumber,
            OutboundDate = o.OutboundDate,

            Status = o.Status switch
            {
                StatusEnum.EnviadaASucursal => "Enviada a Sucursal",
                StatusEnum.RecibidoEnSucursal => "Recibido en Sucursal",
                _ => o.Status.ToString()
            },

            ReceivedDate = o.ReceivedDate,
            ReceivedBy = o.ReceivedUser?.FullName ?? "Pendiente",

            TotalUnits = o.OutboundDetails.Sum(od => od.Quantity),
            TotalCost = o.OutboundDetails.Sum(od => od.SubTotal)
        }).ToList();

        return result;
    }
}
