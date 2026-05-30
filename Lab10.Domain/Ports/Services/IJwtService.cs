namespace Lab10.Domain.Ports.Services;

public interface IJwtService
{
    string GenerateToken(
        string username);
}