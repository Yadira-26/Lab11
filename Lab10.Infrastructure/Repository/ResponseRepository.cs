using Lab10.Domain;
using Lab10.Domain.Entities;
using Lab10.Domain.Ports.Repository;


namespace Lab10.Infrastructure.Repository;

public class ResponseRepository
    : Repository<Response>,
        IResponseRepository
{
    public ResponseRepository(
        AppDbContext context)
        : base(context)
    {
    }
}