using Lab10.Domain.Ports.Services;
using MediatR;

namespace Lab10.Application.ExcelUseCases.Commands;

public record GenerateTableExcelUseCase()
    : IRequest<byte[]>;

internal sealed class GenerateTableExcelUseCaseHandler
    : IRequestHandler<GenerateTableExcelUseCase, byte[]>
{
    private readonly IExcelService _excelService;

    public GenerateTableExcelUseCaseHandler(
        IExcelService excelService)
    {
        _excelService = excelService;
    }

    public async Task<byte[]> Handle(
        GenerateTableExcelUseCase request,
        CancellationToken cancellationToken)
    {
        return await Task.FromResult(
            _excelService.GenerateTableExcel()
        );
    }
}