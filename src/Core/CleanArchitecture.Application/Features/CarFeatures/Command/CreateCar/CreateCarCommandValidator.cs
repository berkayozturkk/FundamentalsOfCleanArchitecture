using FluentValidation;

namespace CleanArchitecture.Application.Features.CarFeatures.Command.CreateCar;

public sealed class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
{
    public CreateCarCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty().WithMessage("Vehicle name cannot be empty");
        RuleFor(p => p.Name).NotNull().WithMessage("Vehicle name cannot be empty");
        RuleFor(p => p.Name).MinimumLength(2).WithMessage("Vehicle name cannot be shorter than 2 letters");

        RuleFor(p => p.Model).NotEmpty().WithMessage("Model name cannot be empty");
        RuleFor(p => p.Model).NotNull().WithMessage("Model name cannot be empty");
        RuleFor(p => p.Model).MinimumLength(2).WithMessage("Model name cannot be shorter than 2 letters");

        RuleFor(p => p.EnginePower).NotEmpty().WithMessage("Engine power name cannot be empty");
        RuleFor(p => p.EnginePower).NotNull().WithMessage("Engine power name cannot be empty");
        RuleFor(p => p.EnginePower).GreaterThan(0).WithMessage("Engine power cannot be 0");
    }
}
