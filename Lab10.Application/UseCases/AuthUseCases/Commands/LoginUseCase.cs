using Lab10.Domain.DTOs;
using Lab10.Domain.Ports.Repository;
using Lab10.Domain.Ports.Services;

namespace Lab10.Application.UseCases.Auth;

public class LoginUseCase
{
    private readonly IUserRepository _userRepository;

    private readonly IJwtService _jwtService;

    private readonly IPasswordHasher _passwordHasher;

    public LoginUseCase(
        IUserRepository userRepository,
        IJwtService jwtService,
        IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;

        _jwtService = jwtService;

        _passwordHasher = passwordHasher;
    }

    public async Task<string> ExecuteAsync(
        LoginDTO dto)
    {
        var user =
            await _userRepository
                .GetByUsernameAsync(
                    dto.Username);

        if (user == null)
        {
            throw new Exception(
                "Usuario no encontrado");
        }

        var validPassword =
            _passwordHasher.Verify(
                dto.Password,
                user.PasswordHash);

        if (!validPassword)
        {
            throw new Exception(
                "Contraseña incorrecta");
        }

        return _jwtService
            .GenerateToken(
                user.Username);
    }
}