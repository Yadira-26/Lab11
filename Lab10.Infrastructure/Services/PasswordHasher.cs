using Lab10.Domain.Ports.Services;

namespace Lab10.Infrastructure.Services;

public class PasswordHasher
    : IPasswordHasher
{
    public string Hash(string password)
    {
        return BCrypt.Net.BCrypt
            .HashPassword(password);
    }

    public bool Verify(
        string password,
        string hash)
    {
        return BCrypt.Net.BCrypt
            .Verify(password, hash);
    }
}