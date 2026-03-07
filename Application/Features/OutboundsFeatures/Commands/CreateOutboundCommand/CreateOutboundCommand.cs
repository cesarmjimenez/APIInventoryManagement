using Application.DTOs.OutboundsDtos;
using Application.Interfaces;
using Application.Specifications.InventorySpecifications;
using Application.Specifications.LocationsSpecifications;
using Application.Specifications.OutboundsSpecifications;
using Application.Specifications.ProductBatchesSpecifications;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Application.Features.OutboundsFeatures.Commands.CreateOutboundCommand;

public class CreateOutboundCommand : IRequest<Response<OutboundResponseDto>>
{
    public Guid DestinationId { get; set; }

    public List<OutboundItemDto>? Items { get; set; } = [];
}

public class CreateOutboundCommandHandler(
    IRepositoryAsync<Outbounds> outboundRepositoryAsync,
    IRepositoryAsync<OutboundDetails> outboundDetailsRepositoryAsync,
    IRepositoryAsync<ProductBatches> productBatchesRepositoryAsync,
    IRepositoryAsync<Inventory> inventoryRepositoryAsync,
    IRepositoryAsync<Locations> locationsRepositoryAsync,
    IHttpContextAccessor httpContextAccessor,
    IMapper mapper
    ) : IRequestHandler<CreateOutboundCommand, Response<OutboundResponseDto>>
{
    public async Task<Response<OutboundResponseDto>> Handle(CreateOutboundCommand request, CancellationToken cancellationToken)
    {
        var user = httpContextAccessor.HttpContext?.User;
        var userId = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var userRole = user?.FindFirst(ClaimTypes.Role)?.Value;
        if (userRole != "Jefe de Bodega")
            return new Response<OutboundResponseDto>("Solo el Jefe de Bodega puede realizar salidas.")
            { Succeeded = false };

        var originLocation = await locationsRepositoryAsync.FirstOrDefaultAsync(
            new GetCentralWarehouseSpecification(), cancellationToken);

        var pendingOutbound = await outboundRepositoryAsync.ListAsync(new OutboundsByDestinationSpecification(request.DestinationId, StatusEnum.EnviadaASucursal), cancellationToken);

        decimal totalPending = pendingOutbound.Sum(o => o.OutboundDetails.Sum(od => od.SubTotal));

        if (totalPending > 340)
            return new Response<OutboundResponseDto>("No se pueden realizar más salidas a esta sucursal hasta que se reciban las pendientes.")
            { Succeeded = false };

        var newOutbound = new Outbounds
        {
            Id = Guid.NewGuid(),
            OutboundNumber = $"OUT-{DateTime.Now.Ticks}",
            Status = StatusEnum.EnviadaASucursal,
            DestinationId = request.DestinationId,
            OutboundUserId = Guid.Parse(userId!),
            OutboundDate = DateTime.Now,
            OriginLocationId = originLocation!.Id
        };

        var details = new List<OutboundDetails>();

        foreach (var item in request.Items!)
        {
            var batches = await productBatchesRepositoryAsync.ListAsync(
                new BatchesByProductIdSpecification(item.ProductId), cancellationToken);

            var sortedBatches = batches.OrderBy(pb => pb.ExpirationDate).ToList();

            decimal remainingQuantity = item.Quantity;

            if (batches.Sum(b => b.Quantity) < item.Quantity)
                return new Response<OutboundResponseDto>($"Inventario insuficiente para el producto: {item.ProductId}")
                { Succeeded = false };

            foreach (var batch in sortedBatches)
            {
                if (remainingQuantity <= 0)
                    break;

                decimal takeFromBatch = Math.Min(batch.Quantity, remainingQuantity);

                batch.Quantity -= takeFromBatch;
                await productBatchesRepositoryAsync.UpdateAsync(batch, cancellationToken);

                var inventoryItem = await inventoryRepositoryAsync.FirstOrDefaultAsync(
                    new InventoryByLocationsAndBatchSpecification(originLocation.Id, batch.Id));

                if (inventoryItem != null)
                {
                    inventoryItem.StockQuantity -= takeFromBatch;
                    await inventoryRepositoryAsync.UpdateAsync(inventoryItem, cancellationToken);
                }

                details.Add(new OutboundDetails
                {
                    Id = Guid.NewGuid(),
                    OutboundId = newOutbound.Id,
                    ProductBatchId = batch.Id,
                    Quantity = takeFromBatch,
                    SubTotal = takeFromBatch * batch.UnitCost
                });

                remainingQuantity -= takeFromBatch;
            }
        }

        await outboundRepositoryAsync.AddAsync(newOutbound, cancellationToken);
        await outboundDetailsRepositoryAsync.AddRangeAsync(details, cancellationToken);

        return new Response<OutboundResponseDto>(mapper.Map<OutboundResponseDto>(newOutbound), "Salida creada con exito.");
    }
}