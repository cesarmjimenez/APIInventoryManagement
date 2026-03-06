using Application.DTOs.ProductsDtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class ProductsMapper : Profile
{
    public ProductsMapper()
    {
        CreateMap<Products, ProductsDto>();
    }
}
