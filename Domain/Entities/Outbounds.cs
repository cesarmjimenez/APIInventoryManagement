using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Outbounds : IdBaseEntity
{
    public required string OutboundNumber { get; set; }

    public StatusEnum Status { get; set; }

    public Guid OriginLocationId { get; set; }

    public Locations OriginLocation { get; set; } = null!;

    public Guid DestinationId { get; set; }

    public Locations Destination { get; set; } = null!;

    public Guid OutboundUserId { get; set; }

    public Users OutboundUser { get; set; } = null!;

    public Guid ReceivedUserId { get; set; }

    public Users ReceivedUser { get; set; } = null!;
}
