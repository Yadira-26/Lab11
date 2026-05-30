using Lab10.Domain.Entities;

namespace Lab10.Domain.Ports.Repository;

public interface IUserRepository
    : IRepository<User>
{
    Task<User?> GetByUsernameAsync(
        string username);
}