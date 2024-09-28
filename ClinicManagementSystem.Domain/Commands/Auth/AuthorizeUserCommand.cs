using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ClinicManagementSystem.Domain.Results.Auth;
using MediatR;

namespace ClinicManagementSystem.Domain.Commands.Auth;

public class AuthorizeUserCommand: IRequest<AuthorizeUserResult>
{
    [Required, EmailAddress] public string Email { get; set; }

    [Required] public string Password { get; set; }
    
    [JsonIgnore] public int? ExpirationTimeDefault { get; set; }
}