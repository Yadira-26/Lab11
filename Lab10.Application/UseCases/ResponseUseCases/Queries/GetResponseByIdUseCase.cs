using Lab10.Domain.Entities;
using Lab10.Domain.Ports.Repository;
using MediatR;

namespace Lab10.Application.UseCases.ResponseUseCases.Queries;

public record GetResponseByIdUseCase(int ResponseId)
    : IRequest<Response?>;

internal sealed class GetResponseByIdUseCaseHandler
    : IRequestHandler<GetResponseByIdUseCase, Response?>
{
    private readonly IResponseRepository _responseRepository;

    public GetResponseByIdUseCaseHandler(
        IResponseRepository responseRepository)
    {
        _responseRepository = responseRepository;
    }

    public async Task<Response?> Handle(
        GetResponseByIdUseCase request,
        CancellationToken cancellationToken)
    {
        return await _responseRepository
            .GetByIdAsync(request.ResponseId);
    }
}