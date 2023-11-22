using FluentValidation;

namespace CleanArchitecture.Application.Features.RoleFeatures.Commands.CreateRole;

public sealed class CreateRoleCommandValidator :
    AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty().WithMessage("Role name cannot be empty!");
        RuleFor(p => p.Name).NotNull().WithMessage("Role name cannot be null!");
    }
}
