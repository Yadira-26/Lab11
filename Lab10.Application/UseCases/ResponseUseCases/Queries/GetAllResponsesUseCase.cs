using Lab10.Domain.Entities;
using Lab10.Domain.Ports.Repository;
using MediatR;

namespace Lab10.Application.UseCases.ResponseUseCases.Queries;

public record GetAllResponsesUseCase
    : IRequest<IEnumerable<Response>>;

internal sealed class GetAllResponsesUseCaseHandler
    : IRequestHandler<GetAllResponsesUseCase, IEnumerable<Response>>
{
    private readonly IResponseRepository _responseRepository;

    public GetAllResponsesUseCaseHandler(
        IResponseRepository responseRepository)
    {
        _responseRepository = responseRepository;
    }

    public async Task<IEnumerable<Response>> Handle(
        GetAllResponsesUseCase request,
        CancellationToken cancellationToken)
    {
        return await _responseRepository.GetAllAsync();
    }
}
