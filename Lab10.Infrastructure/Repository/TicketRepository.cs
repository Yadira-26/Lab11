using Lab10.Domain;
using Lab10.Domain.Entities;
using Lab10.Domain.Ports.Repository;

namespace Lab10.Infrastructure.Repository;

public class TicketRepository
    : Repository<Ticket>,
        ITicketRepository
{
    public TicketRepository(
        AppDbContext context)
        : base(context)
    {
    }
}