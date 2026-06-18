using Lab10.Application.ExcelUseCases.Commands;
using Lab10.Application.ExcelUseCases.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LAB10_YZ.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExcelController : ControllerBase
{
    private readonly IMediator _mediator;

    public ExcelController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("generate")]
    public async Task<IActionResult> GenerateExcel()
    {
        var fileBytes = await _mediator.Send(
            new GenerateExcelUseCase());

        return File(
            fileBytes,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            "Reporte.xlsx");
    }
    
    [HttpPut("modify")]
    public async Task<IActionResult> ModifyExcel()
    {
        string path = @"C:\Excel\Reporte.xlsx";

        await _mediator.Send(
            new ModifyExcelUseCase(path));

        return Ok("Excel modificado correctamente");
    }
    
    [HttpGet("table")]
    public async Task<IActionResult> GenerateTable()
    {
        var fileBytes = await _mediator.Send(
            new GenerateTableExcelUseCase());

        return File(
            fileBytes,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            "Tabla.xlsx");
    }
    
    [HttpGet("styles")]
    public async Task<IActionResult> GenerateStyles()
    {
        var fileBytes = await _mediator.Send(
            new GenerateStyledExcelUseCase());

        return File(
            fileBytes,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            "Estilos.xlsx");
    }
    
    [HttpGet("clients-report")]
    public async Task<IActionResult> GenerateClientsReport()
    {
        var fileBytes = await _mediator.Send(
            new GenerateClientsReportUseCase());

        return File(
            fileBytes,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            "Clientes.xlsx");
    }

    [HttpGet("orders-report")]
    public async Task<IActionResult> GenerateOrdersReport()
    {
        var fileBytes = await _mediator.Send(
            new GenerateOrdersReportUseCase());

        return File(
            fileBytes,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            "Ordenes.xlsx");
    }
    
}