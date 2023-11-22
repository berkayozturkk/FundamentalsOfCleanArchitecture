using CleanArchitecture.Domain.Dtos;
using MediatR;

namespace CleanArchitecture.Application.Features.UserRoleFeatures.Commands.CreateUserRole;

public class CreateUserRoleCommand : IRequest<MessageResponse>
{
    public string RoleId { get; set; }
    public string UserId { get; set; }
}
