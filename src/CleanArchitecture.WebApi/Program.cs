using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Application.Behaviors;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Persistance.Context;
using CleanArchitecture.Persistance.Repositories;
using CleanArchitecture.Persistance.Services;
using CleanArchitecture.WebApi.Middleware;
using CleanArchitecture.WebApi.OptionsSetup;
using CleanArcihtecture.Infrastructure.Authentication;
using CleanArcihtecture.Infrastructure.Services;
using FluentValidation;
using GenericRepository;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICarService,CarService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IMailService, MailService>();

builder.Services.AddTransient<ExceptionMiddleware>();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork<AppDbContext>>();
builder.Services.AddScoped<ICarRepository,CarRepository>();

builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<JwtOption, JwtOption>();

builder.Services.ConfigureOptions<JwtOptionSetup>();
builder.Services.Configure<JwtOption>(builder.Configuration.GetSection("Jwt"));
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthentication();

builder.Services.AddAutoMapper(typeof
    (CleanArchitecture.Persistance.AssemblyReferance).Assembly);

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddIdentity<AppUser,Role>()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddControllers()
    .AddApplicationPart(
    typeof(CleanArchitecture.Presentation.AssemblyReferance).Assembly);

builder.Services.AddMediatR
    (cfr => cfr.RegisterServicesFromAssemblies(
        typeof(CleanArchitecture.Application.AssemblyReference).Assembly));

builder.Services.AddTransient(typeof(IPipelineBehavior<,>),
    typeof(ValidationBehavior<,>));

builder.Services.AddValidatorsFromAssembly(
    typeof(CleanArchitecture.Application.AssemblyReference).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setup =>
{
    var jwtSecuritySheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Put **_ONLY_** yourt JWT Bearer token on textbox below!",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    setup.AddSecurityDefinition(jwtSecuritySheme.Reference.Id, jwtSecuritySheme);

    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecuritySheme, Array.Empty<string>() }
                });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddlewareExtensions();

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
