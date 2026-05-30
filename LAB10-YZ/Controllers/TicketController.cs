using Lab10.Application.UseCases.TicketUseCases.Commands;
using Lab10.Application.UseCases.TicketUseCases.Queries;
using Lab10.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LAB10_YZ.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TicketController : ControllerBase
{
    private readonly IMediator _mediator;

    public TicketController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tickets =
            await _mediator.Send(
                new GetAllTicketsUseCase());

        return Ok(tickets);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(
        int id)
    {
        var ticket =
            await _mediator.Send(
                new GetTicketByIdUseCase(id));

        if (ticket is null)
        {
            return NotFound();
        }

        return Ok(ticket);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        TicketDTO dto)
    {
        var ticketId =
            await _mediator.Send(
                new CreateTicketUseCase(
                    dto.UserId,
                    dto.Title,
                    dto.Description,
                    dto.Status));

        return Ok(new
        {
            message = "Ticket creado correctamente",
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update(
        TicketDTO dto)
    {
        var updated =
            await _mediator.Send(
                new UpdateTicketUseCase(
                    dto.TicketId,
                    dto.UserId,
                    dto.Title,
                    dto.Description,
                    dto.Status,
                    dto.ClosedAt));

        if (!updated)
        {
            return NotFound();
        }

        return Ok(new
        {
            message = "Ticket actualizado correctamente",
        });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(
        int id)
    {
        var deleted =
            await _mediator.Send(
                new DeleteTicketUseCase(id));

        if (!deleted)
        {
            return NotFound();
        }

        return Ok(new
        {
            message = "Ticket eliminado correctamente",
        });
    }
}

