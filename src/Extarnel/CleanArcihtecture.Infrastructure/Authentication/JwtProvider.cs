﻿using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CleanArcihtecture.Infrastructure.Authentication;

public sealed class JwtProvider : IJwtProvider
{
    private readonly JwtOption _jwtOptions;
    private readonly UserManager<AppUser> _userManager;

    public JwtProvider(IOptions<JwtOption> jwtOptions, UserManager<AppUser> userManager)
    {
        _jwtOptions = jwtOptions.Value;
        _userManager = userManager;
    }

    public async Task<LoginCommandResponse> CreateTokenAsync(AppUser user)
    {
        
        var claims = new Claim[]
        {
        new Claim(ClaimTypes.Email,user.Email),
        new Claim(JwtRegisteredClaimNames.Name,user.UserName),
        new Claim("UserName",user.UserName),
        };

        DateTime expires = DateTime.Now.AddHours(1);

        JwtSecurityToken jwtSecurityToken = new(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: claims,
            notBefore: DateTime.Now,
            expires: expires,
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)), SecurityAlgorithms.HmacSha256));

        string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        string refrensToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));

        user.RefreshToken = refrensToken;
        user.RefreshTokenExpries = expires.AddMinutes(15);
        await _userManager.UpdateAsync(user);

        LoginCommandResponse response = new(
            token,
            refrensToken,
            user.RefreshTokenExpries,
            user.Id);

        return response;
    }
}
