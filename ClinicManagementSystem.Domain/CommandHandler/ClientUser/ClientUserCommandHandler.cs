using ClinicManagementSystem.Domain.Commands.UserClient;
using ClinicManagementSystem.Domain.Contracts.Repositories;
using ClinicManagementSystem.Domain.Entities;
using ClinicManagementSystem.Domain.Results.UserClient;
using ClinicManagementSystem.Domain.Validators;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ClinicManagementSystem.Domain.CommandHandler.ClientUser;

public class ClientUserCommandHandler :
    IRequestHandler<CreateClientUserByClinicManagementSystemCommand, BaseClientUserResult>
{

    private readonly IUserRepository _userRepository;
    
    public ClientUserCommandHandler(IUserRepository userRepository)
    {

        _userRepository = userRepository;
    }

    public async Task<BaseClientUserResult> Handle(CreateClientUserByClinicManagementSystemCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseClientUserResult();
        
        var validator = new CreateClientUserValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            response.Message = "opa, algo não funcionou";
            return response;
        }

        var newUser = User.New(
            request.Name,
            request.Email,
            request.Password,
            request.UserType
        );

        await _userRepository.AddUserAsync(newUser);
        

        response.Success = true;
        return response;
    }
}