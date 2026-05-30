using Lab10.Domain.Entities;
using Lab10.Domain.Ports.Repository;
using MediatR;

namespace Lab10.Application.UseCases.RoleUseCases.Commands;

public record UpdateRoleUseCase(
    int RoleId,
    string RoleName
) : IRequest<bool>;

internal sealed class UpdateRoleUseCaseHandler
    : IRequestHandler<UpdateRoleUseCase, bool>
{
    private readonly IRoleRepository _roleRepository;

    private readonly IUnitOfWork _unitOfWork;

    public UpdateRoleUseCaseHandler(
        IRoleRepository roleRepository,
        IUnitOfWork unitOfWork)
    {
        _roleRepository = roleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(
        UpdateRoleUseCase request,
        CancellationToken cancellationToken)
    {
        var role = await _roleRepository
            .GetByIdAsync(request.RoleId);

        if (role is null)
            return false;

        role.RoleName = request.RoleName;

        _roleRepository.Update(role);

        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}