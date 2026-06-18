using ClosedXML.Excel;
using Lab10.Domain.DTOs;
using Lab10.Domain.Ports.Services;

namespace Lab10.Infrastructure.Services;

public class ExcelService : IExcelService
{
    public byte[] GenerateExcel()
    {
        using var workbook = new XLWorkbook();

        var worksheet = workbook.Worksheets.Add("Hoja1");

        worksheet.Cell(1, 1).Value = "Nombre";
        worksheet.Cell(1, 2).Value = "Edad";

        worksheet.Cell(2, 1).Value = "Juan";
        worksheet.Cell(2, 2).Value = 28;

        using var stream = new MemoryStream();

        workbook.SaveAs(stream);

        return stream.ToArray();
    }

    public void ModifyExcel(string filePath)
    {
        using var workbook = new XLWorkbook(filePath);

        var worksheet = workbook.Worksheet(1);

        worksheet.Cell(2, 2).Value = 30;

        workbook.Save();
    }

    public byte[] GenerateTableExcel()
    {
        using var workbook = new XLWorkbook();

        var worksheet = workbook.Worksheets.Add("Datos");

        worksheet.Cell(1, 1).Value = "ID";
        worksheet.Cell(1, 2).Value = "Nombre";
        worksheet.Cell(1, 3).Value = "Edad";

        worksheet.Cell(2, 1).Value = 1;
        worksheet.Cell(2, 2).Value = "Juan";
        worksheet.Cell(2, 3).Value = 28;

        worksheet.Cell(3, 1).Value = 2;
        worksheet.Cell(3, 2).Value = "Maria";
        worksheet.Cell(3, 3).Value = 34;

        var range = worksheet.Range("A1:C3");

        range.CreateTable();

        using var stream = new MemoryStream();

        workbook.SaveAs(stream);

        return stream.ToArray();
    }

    public byte[] GenerateStyledExcel()
    {
        using var workbook = new XLWorkbook();

        var worksheet = workbook.Worksheets.Add("Estilos");

        var headerRow = worksheet.Row(1);

        headerRow.Style.Font.Bold = true;
        headerRow.Style.Fill.BackgroundColor = XLColor.Cyan;
        headerRow.Style.Alignment.Horizontal =
            XLAlignmentHorizontalValues.Center;

        worksheet.Cell(1, 1).Value = "ID";
        worksheet.Cell(1, 2).Value = "Nombre";
        worksheet.Cell(1, 3).Value = "Edad";

        worksheet.Cell(2, 1).Value = 1;
        worksheet.Cell(2, 2).Value = "Juan";
        worksheet.Cell(2, 3).Value = 28;

        using var stream = new MemoryStream();

        workbook.SaveAs(stream);

        return stream.ToArray();
    }

    public byte[] GenerateClientsReport(
        List<ClientDTO> clients)
    {
        using var workbook = new XLWorkbook();

        var worksheet =
            workbook.Worksheets.Add("Clientes");

        worksheet.Cell(1, 1).Value = "ClientId";
        worksheet.Cell(1, 2).Value = "Nombre";
        worksheet.Cell(1, 3).Value = "Email";

        var row = 2;

        foreach (var client in clients)
        {
            worksheet.Cell(row, 1).Value =
                client.ClientId;

            worksheet.Cell(row, 2).Value =
                client.Name;

            worksheet.Cell(row, 3).Value =
                client.Email;

            row++;
        }

        worksheet.Columns().AdjustToContents();

        using var stream = new MemoryStream();

        workbook.SaveAs(stream);

        return stream.ToArray();
    }

    public byte[] GenerateOrdersReport(
        List<OrderDTO> orders)
    {
        using var workbook = new XLWorkbook();

        var worksheet =
            workbook.Worksheets.Add("Ordenes");

        worksheet.Cell(1, 1).Value = "OrderId";
        worksheet.Cell(1, 2).Value = "Cliente";
        worksheet.Cell(1, 3).Value = "Fecha";

        var row = 2;

        foreach (var order in orders)
        {
            worksheet.Cell(row, 1).Value =
                order.OrderId;

            worksheet.Cell(row, 2).Value =
                order.ClientName;

            worksheet.Cell(row, 3).Value =
                order.OrderDate;

            row++;
        }

        worksheet.Columns().AdjustToContents();

        using var stream = new MemoryStream();

        workbook.SaveAs(stream);

        return stream.ToArray();
    }
}