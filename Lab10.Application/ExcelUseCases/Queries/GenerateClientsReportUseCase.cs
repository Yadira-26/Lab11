using Lab10.Domain.Ports.Repository;
using Lab10.Domain.Ports.Services;
using MediatR;

namespace Lab10.Application.ExcelUseCases.Queries;

public record GenerateClientsReportUseCase()
    : IRequest<byte[]>;

internal sealed class GenerateClientsReportUseCaseHandler
    : IRequestHandler<GenerateClientsReportUseCase, byte[]>
{
    private readonly IClientRepository _clientRepository;

    private readonly IExcelService _excelService;

    public GenerateClientsReportUseCaseHandler(
        IClientRepository clientRepository,
        IExcelService excelService)
    {
        _clientRepository = clientRepository;
        _excelService = excelService;
    }

    public async Task<byte[]> Handle(
        GenerateClientsReportUseCase request,
        CancellationToken cancellationToken)
    {
        var clients =
            await _clientRepository.GetClientsReportAsync();

        return _excelService.GenerateClientsReport(
            clients);
    }
}