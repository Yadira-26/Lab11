using Lab10.Domain.Ports.Repository;
using MediatR;

namespace Lab10.Application.UseCases.TicketUseCases.Commands;

public record UpdateTicketUseCase(
    int TicketId,
    int UserId,
    string Title,
    string? Description,
    string Status,
    DateTime? ClosedAt)
    : IRequest<bool>;

internal sealed class UpdateTicketUseCaseHandler
    : IRequestHandler<UpdateTicketUseCase, bool>
{
    private readonly ITicketRepository _ticketRepository;

    private readonly IUnitOfWork _unitOfWork;

    public UpdateTicketUseCaseHandler(
        ITicketRepository ticketRepository,
        IUnitOfWork unitOfWork)
    {
        _ticketRepository = ticketRepository;

        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(
        UpdateTicketUseCase request,
        CancellationToken cancellationToken)
    {
        var ticket = await _ticketRepository
            .GetByIdAsync(request.TicketId);

        if (ticket is null)
            return false;

        ticket.UserId = request.UserId;

        ticket.Title = request.Title;

        ticket.Description = request.Description;

        ticket.Status = request.Status;

        ticket.ClosedAt = request.ClosedAt;

        _ticketRepository.Update(ticket);

        await _unitOfWork
            .SaveChangesAsync();

        return true;
    }
}