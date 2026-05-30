using Lab10.Domain;
using Lab10.Domain.Entities;
using Lab10.Domain.Ports.Repository;
using Microsoft.EntityFrameworkCore;

namespace Lab10.Infrastructure.Repository;

public class UserRepository
    : Repository<User>,
        IUserRepository
{
    public UserRepository(
        AppDbContext context)
        : base(context)
    {
    }

    public async Task<User?> GetByUsernameAsync(
        string username)
    {
        return await Context.Users
            .FirstOrDefaultAsync(
                x => x.Username == username);
    }
}