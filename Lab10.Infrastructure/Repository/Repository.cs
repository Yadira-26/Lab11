using Lab10.Domain;
using Lab10.Domain.Ports.Repository;

using Microsoft.EntityFrameworkCore;

namespace Lab10.Infrastructure.Repository;

public class Repository<T>
    : IRepository<T>
    where T : class
{
    protected readonly AppDbContext Context;

    public Repository(AppDbContext context)
    {
        Context = context;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await Context.Set<T>()
            .ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await Context.Set<T>()
            .FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await Context.Set<T>()
            .AddAsync(entity);
    }

    public void Update(T entity)
    {
        Context.Set<T>()
            .Update(entity);
    }

    public void Delete(T entity)
    {
        Context.Set<T>()
            .Remove(entity);
    }
}