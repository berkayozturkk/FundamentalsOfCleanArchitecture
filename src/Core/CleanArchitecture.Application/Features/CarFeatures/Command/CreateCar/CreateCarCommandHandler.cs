using CleanArchitecture.Domain.Dtos;
using MediatR;

namespace CleanArchitecture.Application.Features.CarFeatures.Command.CreateCar;

public sealed class CreateCarCommandHandler
    : IRequestHandler<CreateCarCommand, MessageResponse>
{
    public async Task<MessageResponse> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        return new("Car Added",true,null);
    }
}
