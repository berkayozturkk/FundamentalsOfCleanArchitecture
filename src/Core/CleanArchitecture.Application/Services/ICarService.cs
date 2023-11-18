using CleanArchitecture.Application.Features.CarFeatures.Command.CreateCar;
using CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Services;

public interface ICarService
{
    Task CreateAsync(CreateCarCommand request, CancellationToken cancellationToken);
    Task<IList<Car>> GetAllAsync(GetAllCarQuery request, CancellationToken cancellationToken);
}
