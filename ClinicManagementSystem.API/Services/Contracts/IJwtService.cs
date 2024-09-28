using ClinicManagementSystem.Domain.Entities;

namespace ClinicManagementSystem.API.Services.Contracts;

public interface IJwtService
{
    string GenerateToken(User usuario);
}