using CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitecture.Application.Services;
using FluentValidation;
using MediatR;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken;

public sealed record CreateNewTokenByRefreshTokenCommand(
    string UserId,
    string RefreshToken): IRequest<LoginCommandResponse>
{}

public sealed class CreateNewTokenByRefreshTokenCommandHandler :
    IRequestHandler<CreateNewTokenByRefreshTokenCommand, LoginCommandResponse>
{
    private readonly IAuthService _authService;

    public CreateNewTokenByRefreshTokenCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<LoginCommandResponse> Handle(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        LoginCommandResponse response = await _authService.CreateTokenByRefreshTokanAsync(request, cancellationToken);
        return response;
    }
}

public sealed class CreateNewTokenByRefreshTokenValidator : AbstractValidator<CreateNewTokenByRefreshTokenCommand>
{
    public CreateNewTokenByRefreshTokenValidator()
    {
        RuleFor(p => p.UserId).NotEmpty().WithMessage("User information cannot be empty!");
        RuleFor(p => p.UserId).NotNull().WithMessage("User information cannot be null!");
        RuleFor(p => p.RefreshToken).NotNull().WithMessage("Refresh Token information cannot be null!");
        RuleFor(p => p.RefreshToken).NotEmpty().WithMessage("Refresh Token information cannot be empty!");
    }
}
