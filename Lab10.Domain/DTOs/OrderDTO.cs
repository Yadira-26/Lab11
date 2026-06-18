namespace Lab10.Domain.DTOs;

public class OrderDTO
{
    public int OrderId { get; set; }

    public string ClientName { get; set; } = string.Empty;

    public DateTime OrderDate { get; set; }
}