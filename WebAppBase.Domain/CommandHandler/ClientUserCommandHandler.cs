using WebAppBase.Shared.Constants;
using WebAppBase.Shared.Notifications;
using WebAppBase.Shared.Persistence;
using WebAppBase.Shared.Security;
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
    IRequestHandler<CreateClientUserCommand, BaseClientUserResult>,
    IRequestHandler<AuthorizeUserCommand, AuthorizeUserResult>
{

    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;
    private readonly IPasswordService _passwordService;
    
    public ClientUserCommandHandler(IUnitOfWork uow, IDomainNotification notifications, IUserRepository userRepository, IJwtService jwtService, IPasswordService passwordService) : base(uow, notifications)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
        _passwordService = passwordService;
    }

    public async Task<BaseClientUserResult> Handle(CreateClientUserCommand command, CancellationToken cancellationToken)
    {
        var response = new BaseClientUserResult();
        
        var validator = new CreateClientUserValidator();
        var validationResult = await validator.ValidateAsync(command);

        if (!validationResult.IsValid)
        {
            response.Success = false;
            response.Message = CommonMessages.UnprocessableEntity;
            return response;
        }

        // Hash the password before saving to database
        var hashedPassword = _passwordService.HashPassword(command.Password);
        
        var newUser = User.New(
            command.Name,
            command.Email,
            hashedPassword,
            command.UserType
        );

        var user = await _userRepository.FindAsync(x => x.Email != null && x.Email.ToLower() == command.Email.ToLower());

        if (user is not null)
        {
            response.Success = false;
            response.Error = CommonMessages.UserAlreadyExists;
            return response;
        }

        await _userRepository.AddUserAsync(newUser);
        
        if (!await CommitAsync())
        {
            Notifications.Handle(CommonMessages.ProblemSavingData);
            response.Success = false;
            response.Message = CommonMessages.ProblemSavingData;
            return response;
        }

        response.Success = true;
        response.Message = CommonMessages.CreateUserSuccess;
        return response;

    }

    public async Task<AuthorizeUserResult> Handle(AuthorizeUserCommand command, CancellationToken cancellationToken)
    {
        var response = new AuthorizeUserResult();
        
        try
        {
            var validator = new AuthUserValidator();
            var validationResult = await validator.ValidateAsync(command);
            
            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Error = CommonMessages.InvalidCredentials;
                return response;
            }

            // Find user by email only
            var user = await _userRepository.FindAsync(x => x.Email != null && x.Email.ToLower() == command.Email.ToLower());

            // Check if user exists and password is correct
            if (user is not null && _passwordService.VerifyPassword(command.Password, user.Password))
            {
                response.AccessToken = _jwtService.GenerateToken(user);
                response.Success = true;
                return response;
            }
            
            // User not found or invalid credentials
            response.Success = false;
            response.Error = CommonMessages.InvalidCredentials;
            return response;
        }
        catch (Exception)
        {
            // Log the exception here if you have logging configured
            response.Success = false;
            response.Error = CommonMessages.UnexpectedError;
            return response;
        }
    }
}