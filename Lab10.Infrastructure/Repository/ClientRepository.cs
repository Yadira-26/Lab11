using Lab10.Domain.DTOs;
using Lab10.Domain.Entities;
using Lab10.Domain.Ports.Repository;
using Lab10.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Lab10.Infrastructure.Repository;

public class ClientRepository
    : Repository<Client>,
        IClientRepository
{
    private readonly LinqExampleDbContext _context;

    public ClientRepository(
        LinqExampleDbContext context)
        : base(context)
    {
        _context = context;
    }

    public async Task<List<ClientDTO>>
        GetClientsReportAsync()
    {
        return await _context.Clients
            .Select(c => new ClientDTO()
            {
                ClientId = c.Clientid,
                Name = c.Name,
                Email = c.Email
            })
            .ToListAsync();
    }
}