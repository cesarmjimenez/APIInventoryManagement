namespace Application.DTOs.OutboundsDtos;

public class OutboundResponseDto
{
    public Guid Id { get; set; }

    public string? OutboundNumber { get; set; }

    public string? Status { get; set; }

    public DateTime OutboundDate { get; set; }
}
