using ClinicManagementSystem.Api.Config;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ClinicManagementSystem.Domain.Commands.UserClient;
using ClinicManagementSystem.Shared.Notifications;

namespace ClinicManagementSystem.API.Controllers;

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
    [Route("/v1/Create")]
    public async Task<IActionResult> Create(CreateClientUserByClinicManagementSystemCommand command,
        CancellationToken cancellationToken)
    {
        return CreateResponse(await _mediator.Send(command, CancellationToken.None));
    }
}

