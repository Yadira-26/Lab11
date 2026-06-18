using Lab10.Domain;
using Lab10.Domain.Entities;
using Lab10.Domain.Ports.Repository;
using Microsoft.EntityFrameworkCore;

namespace Lab10.Infrastructure.Repository;

public class UserRepository
    : Repository<User>,
        IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(
        AppDbContext context)
        : base(context)
    {
        _context = context;
    }

    public async Task<User?> GetByUsernameAsync(
        string username)
    {
        return await _context.Users
            .FirstOrDefaultAsync(
                x => x.Username == username);
    }
}