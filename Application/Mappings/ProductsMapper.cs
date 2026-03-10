using Application.DTOs.ProductsDtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class ProductsMapper : Profile
{
    public ProductsMapper()
    {
        CreateMap<Products, ProductsDto>()
            .ForMember(dest => dest.UnitCost,
            opt => opt.MapFrom(src => src.ProductBatches
            .Where(pb => pb.Quantity > 0)
            .OrderBy(pb => pb.ExpirationDate)
            .Select(pb => pb.UnitCost)
            .FirstOrDefault()));
    }
}
