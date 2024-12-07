using WebAppBase.Shared.Constants;
using WebAppBase.Shared.Notifications;
using WebAppBase.Shared.Persistence;
using MediatR;
using WebAppBase.Domain.Commands.Auth;
using WebAppBase.Domain.Commands.UserClient;
using WebAppBase.Domain.Contracts.Repositories;
using WebAppBase.Domain.Entities;
using WebAppBase.Domain.Results.Auth;
using WebAppBase.Domain.Results.UserClient;
using WebAppBase.Domain.Services.Contracts;
using WebAppBase.Domain.Validators;

namespace WebAppBase.Domain.CommandHandler;

public class ClientUserCommandHandler : BaseCommandHandler,
    IRequestHandler<CreateClientUserByClinicManagementSystemCommand, BaseClientUserResult>,
    IRequestHandler<AuthorizeUserCommand, AuthorizeUserResult>
{

    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;
    
    public ClientUserCommandHandler(IUnitOfWork uow, IDomainNotification notifications, IUserRepository userRepository, IJwtService jwtService) : base(uow, notifications)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
    }

    public async Task<BaseClientUserResult> Handle(CreateClientUserByClinicManagementSystemCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseClientUserResult();
        
        var validator = new CreateClientUserValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            response.Message = CommonMessages.ProblemSavindData;
            return response;
        }

        var newUser = User.New(
            request.Name,
            request.Email,
            request.Password,
            request.UserType
        );

        await _userRepository.AddUserAsync(newUser);
        
        if (!await CommitAsync())
        {
            Notifications.Handle(CommonMessages.ProblemSavindData);
            return response;
        }

        response.Success = true;
        return response;
    }

    public async Task<AuthorizeUserResult> Handle(AuthorizeUserCommand command, CancellationToken cancellationToken)
    {
        var response = new AuthorizeUserResult();
        
        var validator = new AuthUserValidator();
        var validationResult = await validator.ValidateAsync(command);
        
        if (!validationResult.IsValid)
        {
            response.Success = false;
            return response;
        }

        var user = await _userRepository.FindAsync(x => x.Email.ToLower() == command.Email.ToLower() && x.Password == command.Password);

        if (user is not null)
        {
            response.AccessToken = _jwtService.GenerateToken(user);
            response.Success = true;
            return (response);
        }
        
        throw new NotImplementedException();
    }
}