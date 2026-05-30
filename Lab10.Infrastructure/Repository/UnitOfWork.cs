using Lab10.Domain;
using Lab10.Domain.Ports.Repository;

namespace Lab10.Infrastructure.Repository;

public class UnitOfWork
    : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(
        AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context
            .SaveChangesAsync();
    }
}