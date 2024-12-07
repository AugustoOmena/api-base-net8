using WebAppBase.Shared.Enums;
using MediatR;
using WebAppBase.Domain.Results.UserClient;

namespace WebAppBase.Domain.Validators.Requests;

public sealed record CreateUserRequest(string Email, string Name, string Password, EUserType UserType) :
    IRequest<CreateUserResult>
{
    
}