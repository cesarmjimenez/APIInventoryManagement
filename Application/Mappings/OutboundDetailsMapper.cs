using Application.DTOs.OutboundsDtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class OutboundDetailsMapper : Profile
{
    public OutboundDetailsMapper()
    {
        CreateMap<OutboundDetails, OutboundItemDto>();
    }
}
