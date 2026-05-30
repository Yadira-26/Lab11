using Lab10.Domain.DTOs;
using Lab10.Domain.Entities;
using Lab10.Domain.Ports.Repository;
using Lab10.Domain.Ports.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab10.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    private readonly IUnitOfWork _unitOfWork;

    private readonly IJwtService _jwtService;

    private readonly IPasswordHasher _passwordHasher;

    public AuthController(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        IJwtService jwtService,
        IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _jwtService = jwtService;
        _passwordHasher = passwordHasher;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(
        RegisterDTO dto)
    {
        var existingUser =
            await _userRepository
                .GetByUsernameAsync(
                    dto.Username);

        if (existingUser != null)
        {
            return BadRequest(
                "El usuario ya existe");
        }

        var user = new User
        {
            Username = dto.Username,

            Email = dto.Email,

            PasswordHash =
                _passwordHasher.Hash(
                    dto.Password),

            CreatedAt = DateTime.Now
        };

        await _userRepository
            .AddAsync(user);

        await _unitOfWork
            .SaveChangesAsync();

        return Ok(
            "Usuario registrado");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(
        LoginDTO dto)
    {
        var user =
            await _userRepository
                .GetByUsernameAsync(
                    dto.Username);

        if (user == null)
        {
            return Unauthorized(
                "Usuario no encontrado");
        }

        var validPassword =
            _passwordHasher.Verify(
                dto.Password,
                user.PasswordHash);

        if (!validPassword)
        {
            return Unauthorized(
                "Password incorrecta");
        }

        var token =
            _jwtService.GenerateToken(
                user.Username);

        return Ok(new
        {
            Token = token
        });
    }
}