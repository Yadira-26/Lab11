namespace Lab10.Domain.DTOs;

public class TicketDTO
{
    public int TicketId { get; set; }

    public int UserId { get; set; }

    public string Title { get; set; }

    public string? Description { get; set; }

    public string Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ClosedAt { get; set; }
}