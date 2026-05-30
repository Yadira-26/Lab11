using Lab10.Domain.Entities;
using Lab10.Domain.Ports.Repository;
using MediatR;

namespace Lab10.Application.UseCases.ResponseUseCases.Commands;

public record CreateResponseUseCase(
    int TicketId,
    int ResponderId,
    string Message
) : IRequest<int>;

internal sealed class CreateResponseUseCaseHandler
    : IRequestHandler<CreateResponseUseCase, int>
{
    private readonly IResponseRepository _responseRepository;

    private readonly IUnitOfWork _unitOfWork;

    public CreateResponseUseCaseHandler(
        IResponseRepository responseRepository,
        IUnitOfWork unitOfWork)
    {
        _responseRepository = responseRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(
        CreateResponseUseCase request,
        CancellationToken cancellationToken)
    {
        var response = new Response
        {
            TicketId = request.TicketId,
            ResponderId = request.ResponderId,
            Message = request.Message,
            CreatedAt = DateTime.Now
        };

        await _responseRepository.AddAsync(response);

        await _unitOfWork.SaveChangesAsync();

        return response.ResponseId;
    }
}