using MediatR;

namespace ClinicManagementSystem.API.UseCases.CreateUser;

public sealed record CreateUserRequest(string Email, string Name) :
    IRequest<CreateUserResponse>
{
    
}