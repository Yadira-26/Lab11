using Lab10.Domain.Ports.Repository;
using MediatR;

namespace Lab10.Application.UseCases.TicketUseCases.Commands;

public record DeleteTicketUseCase(int TicketId)
    : IRequest<bool>;

internal sealed class DeleteTicketUseCaseHandler
    : IRequestHandler<DeleteTicketUseCase, bool>
{
    private readonly ITicketRepository _ticketRepository;

    private readonly IUnitOfWork _unitOfWork;

    public DeleteTicketUseCaseHandler(
        ITicketRepository ticketRepository,
        IUnitOfWork unitOfWork)
    {
        _ticketRepository = ticketRepository;

        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(
        DeleteTicketUseCase request,
        CancellationToken cancellationToken)
    {
        var ticket = await _ticketRepository
            .GetByIdAsync(request.TicketId);

        if (ticket is null)
            return false;

        _ticketRepository.Delete(ticket);

        await _unitOfWork
            .SaveChangesAsync();

        return true;
    }
}
