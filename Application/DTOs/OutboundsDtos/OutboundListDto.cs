namespace Application.DTOs.OutboundsDtos;

public class OutboundListDto
{
    public Guid Id { get; set; }

    public string? OutboundNumber { get; set; }

    public required DateTime OutboundDate { get; set; }

    public decimal TotalUnits { get; set; }

    public decimal TotalCost { get; set; }

    public string? Status { get; set; }

    public string? ReceivedBy { get; set; }

    public DateTime? ReceivedDate { get; set; }
}
