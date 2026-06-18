using Lab10.Domain.DTOs;

namespace Lab10.Domain.Ports.Services;

public interface IExcelService
{
    byte[] GenerateExcel();
    void ModifyExcel(string filePath);
    byte[] GenerateTableExcel();
    byte[] GenerateStyledExcel();
    byte[] GenerateClientsReport(List<ClientDTO> clients);
    byte[] GenerateOrdersReport( List<OrderDTO> orders);
}