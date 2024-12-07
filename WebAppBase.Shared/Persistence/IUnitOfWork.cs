namespace WebAppBase.Shared.Persistence;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}