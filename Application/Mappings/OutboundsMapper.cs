using Application.DTOs.OutboundsDtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class OutboundsMapper : Profile
{
    public OutboundsMapper()
    {
        CreateMap<Outbounds, OutboundResponseDto>();
    }
}
