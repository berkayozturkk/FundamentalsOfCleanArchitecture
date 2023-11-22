using FluentValidation;

namespace CleanArchitecture.Application.Features.UserRoleFeatures.Commands.CreateUserRole;

public sealed class CreateUserRoleCommandValidator : AbstractValidator<CreateUserRoleCommand>
{
    public CreateUserRoleCommandValidator()
    {
        RuleFor(p => p.UserId).NotEmpty().WithMessage("User information cannot be empty!");
        RuleFor(p => p.UserId).NotNull().WithMessage("User information cannot be null!");
        RuleFor(p => p.RoleId).NotEmpty().WithMessage("Role information cannot be empty!");
        RuleFor(p => p.RoleId).NotNull().WithMessage("Role information cannot be null!");
    }
}
