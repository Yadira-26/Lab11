using Lab10.Domain.Ports.Repository;
using MediatR;

namespace Lab10.Application.UseCases.UserUseCases.Commands;

public record DeleteUserUseCase(int UserId)
    : IRequest<bool>;

internal sealed class DeleteUserUseCaseHandler
    : IRequestHandler<DeleteUserUseCase, bool>
{
    private readonly IUserRepository _userRepository;

    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserUseCaseHandler(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(
        DeleteUserUseCase request,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository
            .GetByIdAsync(request.UserId);

        if (user is null)
            return false;

        _userRepository.Delete(user);

        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}