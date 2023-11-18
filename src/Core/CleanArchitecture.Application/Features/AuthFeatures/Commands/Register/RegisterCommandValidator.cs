using FluentValidation;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;

public sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(p => p.Email).NotEmpty().WithMessage("Email cannot be empty");
        RuleFor(p => p.Email).NotNull().WithMessage("Email cannot be empty");
        RuleFor(p => p.Email).EmailAddress().WithMessage("Email address is not valid");

        RuleFor(p => p.UserName).NotEmpty().WithMessage("Username cannot be empty");
        RuleFor(p => p.UserName).NotNull().WithMessage("Username cannot be empty");
        RuleFor(p => p.UserName).MinimumLength(3).WithMessage("Username must consist of at least 3 characters");

        RuleFor(p => p.Password).NotEmpty().WithMessage("Password cannot be empty");
        RuleFor(p => p.Password).NotNull().WithMessage("Password cannot be empty");
        RuleFor(p => p.Password).MinimumLength(6).WithMessage("Username must consist of at least 6 characters");
        RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("The password must contain at least one uppercase letter.");
        RuleFor(p => p.Password).Matches("[a-z]").WithMessage("The password must contain at least one lowercase letter.");
        RuleFor(p => p.Password).Matches("[0-9]").WithMessage("The password must contain at least one number and letter.");
        RuleFor(p => p.Password).Matches("[^a-zA-Z0-9]").WithMessage("\r\nThe password must contain at least one special character.");
    }
}
