using WebAppBase.Shared.Enums;

namespace WebAppBase.Domain.Results.UserClient;

public sealed record CreateUserResult
{
    public Guid Id { get; set; }
    
    public string Email { get; set; }
    
    public string Name { get; set; }

    public string Password { get; set; }
    
    public EUserType UserType { get; set; }
}