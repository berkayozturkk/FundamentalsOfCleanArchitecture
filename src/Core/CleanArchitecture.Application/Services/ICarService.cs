using CleanArchitecture.Application.Features.CarFeatures.Command.CreateCar;

namespace CleanArchitecture.Application.Services;

public interface ICarService
{
    Task CreateAsync(CreateCarCommand request, CancellationToken cancellationToken);
}
