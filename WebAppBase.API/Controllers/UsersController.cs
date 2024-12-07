using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAppBase.Domain.Commands.UserClient;
using WebAppBase.Api.Config;
using WebAppBase.Shared.Notifications;

namespace WebAppBase.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : BaseApiController
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator, IDomainNotification notifications) : base(notifications, mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("v1/Create")]
    public async Task<IActionResult> Create(CreateClientUserByClinicManagementSystemCommand command,
        CancellationToken cancellationToken)
    {
        return CreateResponse(await _mediator.Send(command, CancellationToken.None));
    }
}

