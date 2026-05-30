namespace Lab10.Domain.Ports.Services;

public interface IPasswordHasher
{
    string Hash(string password);

    bool Verify(
        string password,
        string hash);
}