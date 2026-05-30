using Lab10.Domain.Entities;
using Lab10.Domain.Ports.Repository;
using MediatR;

namespace Lab10.Application.UseCases.TicketUseCases.Commands;

public record CreateTicketUseCase(
    int UserId,
    string Title,
    string? Description,
    string Status)
    : IRequest<int>;

internal sealed class CreateTicketUseCaseHandler
    : IRequestHandler<CreateTicketUseCase, int>
{
    private readonly ITicketRepository _ticketRepository;

    private readonly IUnitOfWork _unitOfWork;

    public CreateTicketUseCaseHandler(
        ITicketRepository ticketRepository,
        IUnitOfWork unitOfWork)
    {
        _ticketRepository = ticketRepository;

        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(
        CreateTicketUseCase request,
        CancellationToken cancellationToken)
    {
        var ticket = new Ticket
        {
            UserId = request.UserId,

            Title = request.Title,

            Description = request.Description,

            Status = request.Status,

            CreatedAt = DateTime.Now
        };

        await _ticketRepository
            .AddAsync(ticket);

        await _unitOfWork
            .SaveChangesAsync();

        return ticket.TicketId;
    }
}
