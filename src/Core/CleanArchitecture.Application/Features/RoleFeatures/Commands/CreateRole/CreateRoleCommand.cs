using CleanArchitecture.Domain.Dtos;
using MediatR;

namespace CleanArchitecture.Application.Features.RoleFeatures.Commands.CreateRole;

public sealed class CreateRoleCommand : IRequest<MessageResponse>
{
    public string Name { get; set; }
}
