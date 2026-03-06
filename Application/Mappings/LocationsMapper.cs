using Application.DTOs.Locations;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class LocationsMapper : Profile
{
    public LocationsMapper()
    {
        CreateMap<Locations, LocationsDto>();
    }
}
