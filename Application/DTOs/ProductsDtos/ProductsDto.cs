namespace Application.DTOs.ProductsDtos;

public class ProductsDto
{
    public Guid Id { get; set; }

    public string Sku { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Brand { get; set; } = null!;

    public decimal UnitCost { get; set; }
}
