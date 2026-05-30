using Lab10.Domain.Entities;
using Lab10.Domain.Ports.Repository;
using MediatR;

namespace Lab10.Application.UseCases.UserUseCases.Queries;

public record GetAllUserUseCase
    : IRequest<IEnumerable<Domain.Entities.User>>;

internal sealed class GetAllUserUseCaseHandler
    : IRequestHandler<GetAllUserUseCase, IEnumerable<User>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUserUseCaseHandler(
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<User>> Handle(
        GetAllUserUseCase request,
        CancellationToken cancellationToken)
    {
        return await _userRepository.GetAllAsync();
    }
}