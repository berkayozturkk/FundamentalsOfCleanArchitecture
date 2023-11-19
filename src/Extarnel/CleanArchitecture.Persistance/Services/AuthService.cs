using AutoMapper;
using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistance.Services;

public sealed class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;
    private readonly IMailService _mailService;
    private readonly IJwtProvider _jwtProvider;

    public AuthService(UserManager<AppUser> userManager, IMapper mapper, IMailService mailService, IJwtProvider jwtProvider)
    {
        _userManager = userManager;
        _mapper = mapper;
        _mailService = mailService;
        _jwtProvider = jwtProvider;
    }

    public async Task<LoginCommandResponse> CreateTokenByRefreshTokanAsync(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        AppUser user = await _userManager.FindByIdAsync(request.UserId);

        if (user is null)
            throw new Exception("User not found");

        if (user.RefreshToken != request.RefreshToken)
            throw new Exception("Refresh token is invalid");

        if (user.RefreshTokenExpries < DateTime.Now)
            throw new Exception("Refresh token time is invalid");

        LoginCommandResponse response = await _jwtProvider.CreateTokenAsync(user);
        return response;
    }

    public async Task<LoginCommandResponse> LoginAsync(LoginCommand request,
        CancellationToken cancellationToken)
    {
        AppUser? user = await _userManager.Users.Where(
            p => p.UserName == request.UserNameOrEmail 
              || p.Email == request.UserNameOrEmail)
            .FirstOrDefaultAsync(cancellationToken);

        if (user is null) throw new Exception("User not found.");

        bool result = await _userManager.CheckPasswordAsync(user, request.Password);

        if (result)
        {
            LoginCommandResponse response = await _jwtProvider.CreateTokenAsync(user);
            return response;
        }

        throw new Exception("Wrong password.");
    }

    public async Task RegisterAsync(RegisterCommand request)
    {
        AppUser user = _mapper.Map<AppUser>(request);

        IdentityResult result = await _userManager.CreateAsync(user,request.Password);
       
        if (!result.Succeeded)
            throw new Exception(result.Errors.First().Description);

        List<string> emails = new();
        emails.Add(request.Email);
        string subject = "New user registration";
        string body = @$"Welcome {user.UserName}! Ready to join? Simply sign up with your username, email, and secure password. Let's get started together!";

        //await _mailService.SendMailAsync(emails, subject, body,null);
    }
}
