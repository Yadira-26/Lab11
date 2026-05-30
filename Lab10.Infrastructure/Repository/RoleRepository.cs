using Lab10.Domain;
using Lab10.Domain.Entities;
using Lab10.Domain.Ports.Repository;

namespace Lab10.Infrastructure.Repository;

public class RoleRepository
    : Repository<Role>,
        IRoleRepository
{
    public RoleRepository(
        AppDbContext context)
        : base(context)
    {
    }
}