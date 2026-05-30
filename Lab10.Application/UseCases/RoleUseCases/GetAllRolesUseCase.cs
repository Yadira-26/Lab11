using Lab10.Domain.Entities;
using Lab10.Domain.Ports.Repository;
using MediatR;

namespace Lab10.Application.UseCases.RoleUseCases.Queries;

public record GetAllRolesUseCase
    : IRequest<IEnumerable<Role>>;

internal sealed class GetAllRolesUseCaseHandler
    : IRequestHandler<GetAllRolesUseCase, IEnumerable<Role>>
{
    private readonly IRoleRepository _roleRepository;

    public GetAllRolesUseCaseHandler(
        IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<IEnumerable<Role>> Handle(
        GetAllRolesUseCase request,
        CancellationToken cancellationToken)
    {
        return await _roleRepository.GetAllAsync();
    }
}