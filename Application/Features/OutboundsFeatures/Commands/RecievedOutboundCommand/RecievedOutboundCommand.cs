using Application.DTOs.OutboundsDtos;
using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Application.Features.OutboundsFeatures.Commands.RecievedOutboundCommand;

public class RecievedOutboundCommand : IRequest<Response<OutboundResponseDto>>
{
    public Guid OutboundId { get; set; }
}

public class RecievedOutboundCommandHandler(
    IRepositoryAsync<Outbounds> outboundRepositoryAsync,
    IHttpContextAccessor httpContextAccessor,
    IMapper mapper) : IRequestHandler<RecievedOutboundCommand, Response<OutboundResponseDto>>
{
    public async Task<Response<OutboundResponseDto>> Handle(RecievedOutboundCommand request, CancellationToken cancellationToken)
    {
        var outbound = await outboundRepositoryAsync.GetByIdAsync(request.OutboundId, cancellationToken) ??
            throw new ApiException("Salida no encontrada.");

        if (outbound.Status == StatusEnum.RecibidoEnSucursal)
            throw new ApiException("La salida ya fue recibida");

        var user = httpContextAccessor.HttpContext?.User;
        var userId = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        outbound.Status = StatusEnum.RecibidoEnSucursal;
        outbound.ReceivedDate = DateTime.Now;
        outbound.ReceivedUserId = Guid.Parse(userId!);

        await outboundRepositoryAsync.UpdateAsync(outbound, cancellationToken);

        return new Response<OutboundResponseDto>(mapper.Map<OutboundResponseDto>(outbound), "La salida fue recibida correctamente.");
    }
}
