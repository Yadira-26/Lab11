using Lab10.Domain.Entities;
using Lab10.Domain.Ports.Repository;
using MediatR;

namespace Lab10.Application.UseCases.TicketUseCases.Queries;

public record GetAllTicketsUseCase
    : IRequest<IEnumerable<Ticket>>;

internal sealed class GetAllTicketsUseCaseHandler
    : IRequestHandler<GetAllTicketsUseCase, IEnumerable<Ticket>>
{
    private readonly ITicketRepository _ticketRepository;

    public GetAllTicketsUseCaseHandler(
        ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<IEnumerable<Ticket>> Handle(
        GetAllTicketsUseCase request,
        CancellationToken cancellationToken)
    {
        return await _ticketRepository
            .GetAllAsync();
    }
}