using WebAppBase.Domain.Entities;

namespace WebAppBase.Domain.Services.Contracts;

public interface IJwtService
{
    string GenerateToken(User usuario);
}