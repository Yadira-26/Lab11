using Lab10.Domain.DTOs;
using Lab10.Infrastructure.Entities;

namespace Lab10.Domain.Ports.Repository;

public interface IClientRepository
    : IRepository<Client>
{
    Task<List<ClientDTO>> GetClientsReportAsync();
}