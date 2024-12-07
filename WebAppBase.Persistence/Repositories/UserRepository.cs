using Microsoft.EntityFrameworkCore;
using WebAppBase.Domain.Entities;
using WebAppBase.Domain.Interfaces;
using WebAppBase.Persistence.Context;

namespace WebAppBase.Persistence.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<User> GetByEmail(string email, CancellationToken cancellationToken)
    {
        return await Context.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken) ?? throw new InvalidOperationException();
    }
}