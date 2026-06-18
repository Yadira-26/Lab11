using Lab10.Domain.Ports.Services;
using MediatR;

namespace Lab10.Application.ExcelUseCases.Commands;

public record GenerateExcelUseCase()
    : IRequest<byte[]>;

internal sealed class GenerateExcelUseCaseHandler
    : IRequestHandler<GenerateExcelUseCase, byte[]>
{
    private readonly IExcelService _excelService;

    public GenerateExcelUseCaseHandler(
        IExcelService excelService)
    {
        _excelService = excelService;
    }

    public async Task<byte[]> Handle(
        GenerateExcelUseCase request,
        CancellationToken cancellationToken)
    {
        return await Task.FromResult(
            _excelService.GenerateExcel()
        );
    }
}
