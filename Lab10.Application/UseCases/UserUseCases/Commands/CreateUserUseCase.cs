using Lab10.Domain.Entities;
using Lab10.Domain.Ports.Repository;
using MediatR;

namespace Lab10.Application.UseCases.UserUseCases.Commands;

public record CreateUserUseCase(
    string Username,
    string PasswordHash,
    string? Email)
    : IRequest<int>;

internal sealed class CreateUserUseCaseHandler
    : IRequestHandler<CreateUserUseCase, int>
{
    private readonly IUserRepository _userRepository;

    private readonly IUnitOfWork _unitOfWork;

    public CreateUserUseCaseHandler(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;

        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(
        CreateUserUseCase request,
        CancellationToken cancellationToken)
    {
        var user = new User
        {
            Username = request.Username,

            PasswordHash = request.PasswordHash,

            Email = request.Email,

            CreatedAt = DateTime.Now
        };

        await _userRepository
            .AddAsync(user);

        await _unitOfWork
            .SaveChangesAsync();

        return user.UserId;
    }
}
