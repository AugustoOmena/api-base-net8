using ClinicManagementSystem.Shared.Enums;
using MediatR;

namespace ClinicManagementSystem.API.UseCases.CreateUser;

public sealed record CreateUserRequest(string Email, string Name, string Password, EUserType UserType) :
    IRequest<CreateUserResponse>
{
    
}