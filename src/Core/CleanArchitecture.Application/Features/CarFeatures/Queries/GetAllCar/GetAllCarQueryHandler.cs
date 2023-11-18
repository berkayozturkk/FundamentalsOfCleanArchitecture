using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;

public sealed class GetAllCarQueryHandler 
    : IRequestHandler<GetAllCarQuery, IList<Car>>
{
    private readonly ICarService _carSerService;

    public GetAllCarQueryHandler(ICarService carSerService)
    {
        _carSerService = carSerService;
    }

    public async Task<IList<Car>> Handle(GetAllCarQuery request, CancellationToken cancellationToken)
    {
        IList<Car> cars = await _carSerService.GetAllAsync(request, cancellationToken);
        return cars;
    }
}
