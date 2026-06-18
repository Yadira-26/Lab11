using Lab10.Domain.Ports.Services;
using MediatR;

namespace Lab10.Application.ExcelUseCases.Commands;

public record GenerateStyledExcelUseCase()
    : IRequest<byte[]>;

internal sealed class GenerateStyledExcelUseCaseHandler
    : IRequestHandler<GenerateStyledExcelUseCase, byte[]>
{
    private readonly IExcelService _excelService;

    public GenerateStyledExcelUseCaseHandler(
        IExcelService excelService)
    {
        _excelService = excelService;
    }

    public async Task<byte[]> Handle(
        GenerateStyledExcelUseCase request,
        CancellationToken cancellationToken)
    {
        return await Task.FromResult(
            _excelService.GenerateStyledExcel()
        );
    }
}