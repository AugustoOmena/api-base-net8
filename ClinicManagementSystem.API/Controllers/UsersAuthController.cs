using ClinicManagementSystem.API.Services.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ClinicManagementSystem.API.UseCases.Login;
using ClinicManagementSystem.Persistence.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementSystem.API.Controllers;

[Route("api/connect")]
[ApiController]
public class UsersAuthController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IJwtService _jwtService;
    private readonly AppDbContext _context;

    public UsersAuthController(IMediator mediator, IJwtService jwtService, AppDbContext context)
    {
        _mediator = mediator;
        _jwtService = jwtService;
        _context = context;
    }
    
    [HttpPost("token")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginUserRequest command,
        CancellationToken cancellationToken)
    {
        var validator = new LoginUserValidator();
        var validationResult = await validator.ValidateAsync(command);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == command.Email && u.Password == command.Password);

        if (user is not null)
        {
            return Ok(new
            {
                accessToken = _jwtService.GenerateToken(user),
                userInfo = new
                {
                    user.Id,
                    user.Name,
                    user.Email
                },
            });
        }
        //var response = await _mediator.Send(command, cancellationToken);
        return NotFound("Usuário não encontrado.");
    }
}