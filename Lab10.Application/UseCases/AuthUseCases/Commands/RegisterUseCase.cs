
using Lab10.Domain.DTOs;
using Lab10.Domain.Entities;
using Lab10.Domain.Ports.Repository;
using Lab10.Domain.Ports.Services;

namespace Lab10.Application.UseCases.Auth;

public class RegisterUseCase
{
    private readonly IUserRepository _userRepository;

    private readonly IUnitOfWork _unitOfWork;

    private readonly IPasswordHasher _passwordHasher;

    public RegisterUseCase(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
    }

    public async Task ExecuteAsync(
        RegisterDTO dto)
    {
        var existingUser =
            await _userRepository
                .GetByUsernameAsync(
                    dto.Username);

        if (existingUser != null)
        {
            throw new Exception(
                "El usuario ya existe");
        }

        var user = new Lab10.Domain.Entities.User
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
    }
}