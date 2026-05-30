using Lab10.Application.UseCases.ResponseUseCases.Commands;
using Lab10.Application.UseCases.ResponseUseCases.Queries;
using Lab10.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LAB10_YZ.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ResponseController : ControllerBase
{
    private readonly IMediator _mediator;

    public ResponseController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var responses =
            await _mediator.Send(
                new GetAllResponsesUseCase());

        return Ok(responses);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(
        int id)
    {
        var response =
            await _mediator.Send(
                new GetResponseByIdUseCase(id));

        if (response == null)
        {
            return NotFound();
        }

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        ResponseDTO dto)
    {
        var command =
            new CreateResponseUseCase(
                dto.TicketId,
                dto.ResponderId,
                dto.Message);

        await _mediator.Send(command);

        return Ok(new
        {
            message = "Respuesta creada correctamente",
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update(
        ResponseDTO dto)
    {
        var command =
            new UpdateResponseUseCase(
                dto.ResponseId,
                dto.TicketId,
                dto.ResponderId,
                dto.Message,
                dto.CreatedAt);

        var result =
            await _mediator.Send(command);

        if (!result)
        {
            return NotFound();
        }

        return Ok(new
        {
            message = "Respuesta actualizada correctamente",
        });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(
        int id)
    {
        var result =
            await _mediator.Send(
                new DeleteResponseUseCase(id));

        if (!result)
        {
            return NotFound();
        }

        return Ok(new
        {
            message = "Respuesta eliminada correctamente",
        });
    }
}