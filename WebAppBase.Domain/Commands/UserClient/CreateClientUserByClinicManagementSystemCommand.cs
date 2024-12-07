using WebAppBase.Shared.Enums;
using MediatR;
using WebAppBase.Domain.Results.UserClient;

namespace WebAppBase.Domain.Commands.UserClient;

public class CreateClientUserByClinicManagementSystemCommand: IRequest<BaseClientUserResult>
{
    public string Name { get; set; }

    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public EUserType UserType { get; set; }
}