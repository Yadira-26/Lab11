using Lab10.Application.UseCases.RoleUseCases.Commands;
using Lab10.Application.UseCases.RoleUseCases.Queries;
using Lab10.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LAB10_YZ.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class RoleController : ControllerBase
{
    private readonly IMediator _mediator;

    public RoleController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var roles =
            await _mediator.Send(
                new GetAllRolesUseCase());

        return Ok(roles);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(
        int id)
    {
        var role =
            await _mediator.Send(
                new GetRoleByIdUseCase(id));

        if (role == null)
        {
            return NotFound();
        }

        return Ok(role);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        RoleDTO dto)
    {
        var command =
            new CreateRoleUseCase(
                dto.RoleName);

        var result =
            await _mediator.Send(command);

        return Ok(new
        {
            message = "Rol creado correctamente",
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update(
        RoleDTO dto)
    {
        var command =
            new UpdateRoleUseCase(
                dto.RoleId,
                dto.RoleName);

        var result =
            await _mediator.Send(command);

        if (!result)
        {
            return NotFound();
        }

        return Ok(new
        {
            message = "Rol actualizado correctamente",
        });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(
        int id)
    {
        var result =
            await _mediator.Send(
                new DeleteRoleUseCase(id));

        if (!result)
        {
            return NotFound();
        }

        return Ok(new
        {
            message = "Rol eliminado correctamente",
        });
    }
}