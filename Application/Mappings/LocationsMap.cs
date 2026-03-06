using Application.DTOs.Locations;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class LocationsMap : Profile
{
    public LocationsMap()
    {
        CreateMap<Locations, LocationsDto>();
    }
}
