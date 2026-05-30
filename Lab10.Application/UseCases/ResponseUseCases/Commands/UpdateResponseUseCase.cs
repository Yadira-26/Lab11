using Lab10.Domain.Entities;
using Lab10.Domain.Ports.Repository;
using MediatR;

namespace Lab10.Application.UseCases.ResponseUseCases.Commands;

public record UpdateResponseUseCase(
    int ResponseId,
    int TicketId,
    int ResponderId,
    string Message,
    DateTime? CreatedAt
) : IRequest<bool>;

internal sealed class UpdateResponseUseCaseHandler
    : IRequestHandler<UpdateResponseUseCase, bool>
{
    private readonly IResponseRepository _responseRepository;

    private readonly IUnitOfWork _unitOfWork;

    public UpdateResponseUseCaseHandler(
        IResponseRepository responseRepository,
        IUnitOfWork unitOfWork)
    {
        _responseRepository = responseRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(
        UpdateResponseUseCase request,
        CancellationToken cancellationToken)
    {
        var response =
            await _responseRepository
                .GetByIdAsync(request.ResponseId);

        if (response is null)
            return false;

        response.TicketId = request.TicketId;
        response.ResponderId = request.ResponderId;
        response.Message = request.Message;

        _responseRepository.Update(response);

        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}