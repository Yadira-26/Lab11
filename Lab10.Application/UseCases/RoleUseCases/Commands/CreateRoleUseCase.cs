using Lab10.Domain.Entities;
using Lab10.Domain.Ports.Repository;
using MediatR;

namespace Lab10.Application.UseCases.RoleUseCases.Commands;

public record CreateRoleUseCase(
    string RoleName
) : IRequest<int>;

internal sealed class CreateRoleUseCaseHandler
    : IRequestHandler<CreateRoleUseCase, int>
{
    private readonly IRoleRepository _roleRepository;

    private readonly IUnitOfWork _unitOfWork;

    public CreateRoleUseCaseHandler(
        IRoleRepository roleRepository,
        IUnitOfWork unitOfWork)
    {
        _roleRepository = roleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(
        CreateRoleUseCase request,
        CancellationToken cancellationToken)
    {
        var role = new Role
        {
            RoleName = request.RoleName
        };

        await _roleRepository.AddAsync(role);

        await _unitOfWork.SaveChangesAsync();

        return role.RoleId;
    }
}