using Lab10.Domain.Entities;
using Lab10.Domain.Ports.Repository;
using MediatR;

namespace Lab10.Application.UseCases.UserUseCases.Queries;

public record GetUserByIdUseCase(int UserId)
    : IRequest<User?>;

internal sealed class GetUserByIdUseCaseHandler
    : IRequestHandler<GetUserByIdUseCase, User?>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdUseCaseHandler(
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User?> Handle(
        GetUserByIdUseCase request,
        CancellationToken cancellationToken)
    {
        return await _userRepository
            .GetByIdAsync(request.UserId);
    }
}