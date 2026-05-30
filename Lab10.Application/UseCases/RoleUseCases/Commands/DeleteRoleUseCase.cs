using Lab10.Domain.Ports.Repository;
using MediatR;

namespace Lab10.Application.UseCases.RoleUseCases.Commands;

public record DeleteRoleUseCase(
    int RoleId
) : IRequest<bool>;

internal sealed class DeleteRoleUseCaseHandler
    : IRequestHandler<DeleteRoleUseCase, bool>
{
    private readonly IRoleRepository _roleRepository;

    private readonly IUnitOfWork _unitOfWork;

    public DeleteRoleUseCaseHandler(
        IRoleRepository roleRepository,
        IUnitOfWork unitOfWork)
    {
        _roleRepository = roleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(
        DeleteRoleUseCase request,
        CancellationToken cancellationToken)
    {
        var role = await _roleRepository
            .GetByIdAsync(request.RoleId);

        if (role is null)
            return false;

        _roleRepository.Delete(role);

        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}