using Domain.Common;

namespace Domain.Entities;

public class Locations : IdBaseEntity
{
    public required string Name { get; set; }

    public required string Address { get; set; }

    public required string City { get; set; }

    public bool IsWareHouse { get; set; }

    public bool IsActive { get; set; }
}
