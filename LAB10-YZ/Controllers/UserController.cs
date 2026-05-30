using Lab10.Application.UseCases.UserUseCases.Commands;
using Lab10.Application.UseCases.UserUseCases.Queries;
using Lab10.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LAB10_YZ.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users =
            await _mediator.Send(
                new GetAllUserUseCase());

        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(
        int id)
    {
        var user =
            await _mediator.Send(
                new GetUserByIdUseCase(id));

        if (user is null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        UserDTO dto)
    {
        var command =
            new CreateUserUseCase(
                dto.Username,
                dto.PasswordHash,
                dto.Email);

        var result =
            await _mediator.Send(command);

        return Ok(new
        {
            message = "Usuario creado correctamente",
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update(
        UpdateUserUseCase command)
    {
        var result =
            await _mediator.Send(command);

        return Ok(new
        {
            message = "Usuario actualizado correctamente",
        });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(
        int id)
    {
        var result =
            await _mediator.Send(
                new DeleteUserUseCase(id));

        return Ok(new
        {
            message = "Usuario eliminado correctamente",
        });
    }
}

