using Lab10.Domain.Ports.Repository;
using Lab10.Domain.Ports.Services;
using MediatR;

namespace Lab10.Application.ExcelUseCases.Queries;

public record GenerateOrdersReportUseCase()
    : IRequest<byte[]>;

internal sealed class GenerateOrdersReportUseCaseHandler
    : IRequestHandler<GenerateOrdersReportUseCase, byte[]>
{
    private readonly IOrderRepository _orderRepository;

    private readonly IExcelService _excelService;

    public GenerateOrdersReportUseCaseHandler(
        IOrderRepository orderRepository,
        IExcelService excelService)
    {
        _orderRepository = orderRepository;
        _excelService = excelService;
    }

    public async Task<byte[]> Handle(
        GenerateOrdersReportUseCase request,
        CancellationToken cancellationToken)
    {
        var orders =
            await _orderRepository.GetOrdersReportAsync();

        return _excelService.GenerateOrdersReport(
            orders);
    }
}