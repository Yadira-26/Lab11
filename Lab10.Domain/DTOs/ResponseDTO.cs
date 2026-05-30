namespace Lab10.Domain.DTOs;

public class ResponseDTO
{
    public int ResponseId { get; set; }

    public int TicketId { get; set; }

    public int ResponderId { get; set; }

    public string Message { get; set; }

    public DateTime? CreatedAt { get; set; }
}