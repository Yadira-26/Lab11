namespace Lab10.Domain.Ports.Repository;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}