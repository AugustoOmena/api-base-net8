using WebAppBase.Shared.Persistence;
using System.Linq.Expressions;
using WebAppBase.Domain.Entities;
using WebAppBase.Domain.Filters;

namespace WebAppBase.Domain.Contracts.Repositories;

public interface IUserRepository : IRepository<User>
{
    Expression<Func<User, bool>> Where(UserFilter filter);
    Task<T> AddUserAsync<T>(T user);
}