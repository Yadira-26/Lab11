using Lab10.Domain.Entities;
using Lab10.Domain.Ports.Repository;
using MediatR;

namespace Lab10.Application.UseCases.RoleUseCases.Queries;

public record GetRoleByIdUseCase(
    int RoleId
) : IRequest<Role?>;

internal sealed class GetRoleByIdUseCaseHandler
    : IRequestHandler<GetRoleByIdUseCase, Role?>
{
    private readonly IRoleRepository _roleRepository;

    public GetRoleByIdUseCaseHandler(
        IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<Role?> Handle(
        GetRoleByIdUseCase request,
        CancellationToken cancellationToken)
    {
        return await _roleRepository
            .GetByIdAsync(request.RoleId);
    }
}