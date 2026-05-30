using Lab10.Domain.Ports.Repository;
using MediatR;

namespace Lab10.Application.UseCases.UserUseCases.Commands;

public record UpdateUserUseCase : IRequest<bool>
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;
}

internal sealed class UpdateUserUseCaseHandler
    : IRequestHandler<UpdateUserUseCase, bool>
{
    private readonly IUserRepository _userRepository;

    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserUseCaseHandler(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(
        UpdateUserUseCase request,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository
            .GetByIdAsync(request.UserId);

        if (user is null)
            return false;

        user.Username = request.Username;
        user.Email = request.Email;

        _userRepository.Update(user);

        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}