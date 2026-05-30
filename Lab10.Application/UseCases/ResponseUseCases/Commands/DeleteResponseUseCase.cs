using Lab10.Domain.Ports.Repository;
using MediatR;

namespace Lab10.Application.UseCases.ResponseUseCases.Commands;

public record DeleteResponseUseCase(int ResponseId)
    : IRequest<bool>;

internal sealed class DeleteResponseUseCaseHandler
    : IRequestHandler<DeleteResponseUseCase, bool>
{
    private readonly IResponseRepository _responseRepository;

    private readonly IUnitOfWork _unitOfWork;

    public DeleteResponseUseCaseHandler(
        IResponseRepository responseRepository,
        IUnitOfWork unitOfWork)
    {
        _responseRepository = responseRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(
        DeleteResponseUseCase request,
        CancellationToken cancellationToken)
    {
        var response =
            await _responseRepository
                .GetByIdAsync(request.ResponseId);

        if (response is null)
            return false;

        _responseRepository.Delete(response);

        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}