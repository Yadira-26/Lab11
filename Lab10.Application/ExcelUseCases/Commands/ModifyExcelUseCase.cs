using Lab10.Domain.Ports.Services;
using MediatR;

namespace Lab10.Application.ExcelUseCases.Commands;

public record ModifyExcelUseCase(
    string FilePath
) : IRequest<bool>;

internal sealed class ModifyExcelUseCaseHandler
    : IRequestHandler<ModifyExcelUseCase, bool>
{
    private readonly IExcelService _excelService;

    public ModifyExcelUseCaseHandler(
        IExcelService excelService)
    {
        _excelService = excelService;
    }

    public async Task<bool> Handle(
        ModifyExcelUseCase request,
        CancellationToken cancellationToken)
    {
        _excelService.ModifyExcel(request.FilePath);

        return await Task.FromResult(true);
    }
}