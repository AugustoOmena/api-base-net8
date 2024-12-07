using WebAppBase.Domain.Validators.Requests;
using FluentValidation;
using WebAppBase.Domain.Commands.UserClient;

namespace WebAppBase.Domain.Validators;

public sealed class CreateClientUserValidator : AbstractValidator<CreateClientUserByClinicManagementSystemCommand>
{
    public CreateClientUserValidator()
    {
        RuleFor(x => x.Email).NotEmpty().MaximumLength(50).EmailAddress();
        RuleFor(x => x.Name).NotEmpty().MinimumLength(3).MaximumLength(50);
        RuleFor(x => x.Password).NotEmpty().MinimumLength(3).MaximumLength(50);
    }
}