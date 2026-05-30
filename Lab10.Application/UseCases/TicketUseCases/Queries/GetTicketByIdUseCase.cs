using Lab10.Domain.Entities;
using Lab10.Domain.Ports.Repository;
using MediatR;

namespace Lab10.Application.UseCases.TicketUseCases.Queries;

public record GetTicketByIdUseCase(int TicketId)
    : IRequest<Ticket?>;

internal sealed class GetTicketByIdUseCaseHandler
    : IRequestHandler<GetTicketByIdUseCase, Ticket?>
{
    private readonly ITicketRepository _ticketRepository;

    public GetTicketByIdUseCaseHandler(
        ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<Ticket?> Handle(
        GetTicketByIdUseCase request,
        CancellationToken cancellationToken)
    {
        return await _ticketRepository
            .GetByIdAsync(request.TicketId);
    }
}
