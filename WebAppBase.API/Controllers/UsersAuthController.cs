using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAppBase.Domain.Commands.Auth;
using Microsoft.AspNetCore.Authorization;
using WebAppBase.Api.Config;
using WebAppBase.Shared.Notifications;

namespace WebAppBase.API.Controllers;

[Route("api/connect")]
[ApiController]
public class UsersAuthController : BaseApiController
{
    private readonly IMediator _mediator;

    public UsersAuthController(IMediator mediator, IDomainNotification notifications) : base(notifications, mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("token")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(AuthorizeUserCommand command,
        CancellationToken cancellationToken)
    {
        return CreateResponse(await _mediator.Send(command, cancellationToken));
    }
}